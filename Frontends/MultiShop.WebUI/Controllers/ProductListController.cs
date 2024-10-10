using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Utilities.FileOperations;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UIValidations.CommentValidations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;

        public ProductListController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.Directory1 = "Ana Sayfa";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Ürün Listesi";

            ViewBag.i = id;

            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.Directory1 = "Ana Sayfa";
            ViewBag.Directory2 = "Ürün Listesi";
            ViewBag.Directory3 = "Ürün Detayı";

            ViewBag.x = id;

            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var createCommentValidator = new CommentValidator();
            var validation = createCommentValidator.Validate(createCommentDto);

            if (validation.IsValid)
            {
                createCommentDto.ImageUrl = "https://localhost:7155/online-shop-website-template/img/profile-logo.png";
                createCommentDto.Rating = (createCommentDto.Rating == null ? 1 : createCommentDto.Rating);
                createCommentDto.CreatedDate = DateTime.Now;
                createCommentDto.IsActive = false;

                var responseMessage = await _commentService.CreateDataAsync(createCommentDto);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Default");
                }

                return RedirectToAction("NotFound404", "Error");
            }
            else
            {
                return View();
            }
        }

    }
}
