using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var requestMessage = await _commentService.GetCommentByProductId(id);

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
