using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticsServices.CommentStatisticsServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;

        public _AdminLayoutHeaderComponentPartial(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();

            ViewBag.UserName = user.Name + ' ' + user.Username;
            ViewBag.Email = user.Email;
            return View();
        }
    }
}
