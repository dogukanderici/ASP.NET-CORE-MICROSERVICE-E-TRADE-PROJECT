using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutNavbarComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;

        public _UserLayoutNavbarComponentPartial(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();

            ViewBag.NameSurname = user.Name + ' ' + user.Username;
            ViewBag.Email = user.Email;

            return View();
        }
    }
}
