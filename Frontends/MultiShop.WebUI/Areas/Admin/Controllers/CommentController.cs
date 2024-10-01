using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CommentDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Utilities.FileOperations;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.CommentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(int? statusCode)
        {
            SetViewBagContent("Yorum İşlemleri", "Ana Sayfa", "Yorumlar", "Yorum Listesi");

            var responseMessage = await _commentService.GetAllDataAsync();

            if (statusCode != null)
            {
                HttpStatusCode statusCodeStr = (HttpStatusCode)statusCode;
                //SetViewBagStatusInfo(statusCode, statusCodeStr.ToString());
                SetViewBagStatusInfo(statusCode, "Aradığınız Veri Bulunamadı!");
            }

            if (responseMessage.Count() > 0)
            {
                return View(responseMessage);
            }

            return View(new List<ResultCommentDto>());
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var responseMessage = await _commentService.DeleteDataAsync(id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }

            return RedirectToAction("NotFound404", "Error");
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateComment(string id)
        {

            var responseMessage = await _commentService.GetDataAsync(id);

            if (responseMessage == null)
            {
                return View(responseMessage);
            }

            return RedirectToAction("Index", "Comment", new { area = "Admin", statusCode = 404 });
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var updateCommentValidator = new UpdateCommentValidator();
            var validator = updateCommentValidator.Validate(updateCommentDto);

            if (validator.IsValid)
            {
                var responseMessage = await _commentService.UpdateDataAsync(updateCommentDto);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Comment", new { area = "Admin" });
                }

                SetViewBagStatusInfo(404, "Bir Sorun Oluştu. Lütfen Tekrar Deneyiniz!");

                return View("Index");
            }

            return await UpdateComment(updateCommentDto.UserCommentId.ToString());
        }

        void SetViewBagContent(string mainTitle, string homePageTitle, string title, string subTitle)
        {
            ViewBag.v0 = mainTitle;
            ViewBag.v1 = homePageTitle;
            ViewBag.v2 = title;
            ViewBag.v3 = subTitle;
        }

        void SetViewBagStatusInfo(int? statusCode, string statsuMessage)
        {
            ViewBag.StatusCode = statusCode;
            ViewBag.StatusMessage = statsuMessage;
        }
    }
}
