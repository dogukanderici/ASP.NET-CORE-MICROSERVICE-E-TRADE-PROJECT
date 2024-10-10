using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MultiShop.Dtos.CargoDtos.CargoDetailDtos;
using MultiShop.Dtos.CargoDtos.CargoOperationsDtos;
using MultiShop.Dtos.OrderDtos.OrderDetailDtos;
using MultiShop.Dtos.OrderDtos.OrderingDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CargoServices.CargoDetailServices;
using MultiShop.WebUI.Services.CargoServices.CargoOperationsServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderOrderDetailService;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;
using MultiShop.WebUI.Utilities.RazorViewRendererHelper;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        private readonly IBasketService _basketService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly ICargoDetailService _cargoDetailService;
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;
        private readonly IRazorViewRenderer _razorViewRenderer;
        private readonly IMailService _mailService;

        public PaymentController(IOrderAddressService orderAddressService, IUserService userService, IBasketService basketService, IOrderDetailService orderDetailService, IOrderOrderingService orderOrderingService, IMapper mapper, ICargoDetailService cargoDetailService, ICargoOperationService cargoOperationService, IRazorViewRenderer razorViewRenderer, IMailService mailService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
            _basketService = basketService;
            _orderDetailService = orderDetailService;
            _orderOrderingService = orderOrderingService;
            _mapper = mapper;
            _cargoDetailService = cargoDetailService;
            _cargoOperationService = cargoOperationService;
            _razorViewRenderer = razorViewRenderer;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Ödeme Ekranı";
            ViewBag.Directory3 = "Kredi/Banka Kartı";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment()
        {
            // Sisteme giriş yapmış kullanıcının adres bilgilerini getirir.
            var user = await _userService.GetUserInfo();
            var value = await _orderAddressService.GetUserOrderAddressAsync(user.Id);

            // Kullanıcnın sepet bilgisini getirir.
            var values = await _basketService.GetBasket();

            if (values.IsAppliedDiscount)
            {
                //values.TotalPrice = values.BasketItems.Sum(x => x.TotalItemPrice - (x.TotalItemPrice / 100 * values.DiscountRate));

                values.TotalPrice = values.TotalPrice - (values.TotalPrice / 100 * values.DiscountRate);
            }

            // Order ve OrderDetail tablolarına kayıt atmak için gerekli olan mapping işlemlerini yapar.
            var valueFromOrderingDto = _mapper.Map<CreateOrderingDto>(values);
            var valueFromOrderingDetailDto = _mapper.Map<List<CreateOrderDetailDto>>(values.BasketItems);

            // Sistem OrderId için yeni GUID değer oluşturur.
            Guid newGuid = Guid.NewGuid();

            valueFromOrderingDto.OrderDat = DateTime.Now;
            valueFromOrderingDto.OrderingId = newGuid;
            valueFromOrderingDetailDto.ForEach(x => x.OrderingId = newGuid);
            valueFromOrderingDetailDto.ForEach(x => x.ProductTotalPrice = x.ProductPrice);

            // Order ve OrderDetail tablolarına veriler yazılır.
            await _orderOrderingService.CreateOrdering(valueFromOrderingDto);
            await _orderDetailService.CreateOrderDetail(valueFromOrderingDetailDto);

            // CargoDetail tablosuna veriler yazılır.
            await _cargoDetailService.TAddAsync(new CreateCargoDetailDto
            {
                SenderCustomer = "MultiShop",
                RecieverCustomer = user.Name + ' ' + user.Surname,
                Barcode = newGuid,
                CargoCompanyId = int.Parse(values.CargoCompany)
            });

            // CargoOperations tablosuna veriler yazılır.
            await _cargoOperationService.TAddAsync(new CreateCargoOperationDto
            {
                Barcode = newGuid,
                Description = "Sipariş Alındı",
                IsDelivered = false,
                OperationDate = DateTime.Now
            });

            var emailContentModel = new OrderMailViewModel()
            {
                BasketItems = values.BasketItems,
                TotalPrice = values.TotalPrice,
                Address = value.Detail1,
                UserInfo = user
            };

            string emailcontent = await _razorViewRenderer.RenderRazorViewToStringAsync("OrderSummaryEmailTemplate", emailContentModel);

            List<string> ToList = new List<string> { user.Email };

            var mailModel = new SendMailViewModel
            {
                ReceiverMail = ToList,
                Subject = "MultiShop - Sipariş Onayı",
                Body = emailcontent,
                IsSend = false,
                SendDate = DateTime.Now
            };

            _mailService.SendMail(mailModel);

            // Kullanıcıya ait sepet temizlenir.
            await _basketService.DeleteBasket();

            return RedirectToAction("Index", "Default");
        }
    }
}
