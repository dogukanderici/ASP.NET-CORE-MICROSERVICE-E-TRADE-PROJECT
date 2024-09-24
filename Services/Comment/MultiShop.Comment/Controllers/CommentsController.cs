using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities.Concrete;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;
        private readonly IMapper _mapper;

        public CommentsController(CommentContext commentContext, IMapper mapper)
        {
            _commentContext = commentContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();

            var dataToDto = values.Select(x => _mapper.Map<ResultCommentDto>(x)).ToList();

            return Ok(dataToDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var values = _commentContext.UserComments.Find(id);

            var dataToDto = _mapper.Map<GetByIdCommentDto>(values);

            return Ok(dataToDto);
        }

        [HttpPost]
        public IActionResult CreateComment(CreateCommentDto createCommentDto)
        {
            var valueFromDto = _mapper.Map<UserComment>(createCommentDto);

            _commentContext.UserComments.Add(valueFromDto);
            _commentContext.SaveChanges();

            return Ok("Yorum Başarıyla Eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateComment(UpdateCommentDto updateCommentDto)
        {

            var valueFromDto = _mapper.Map<UserComment>(updateCommentDto);

            _commentContext.UserComments.Update(valueFromDto);
            _commentContext.SaveChanges();

            return Ok("Yorum Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);

            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();

            return Ok("Yorum Başarıyla Silindi.");
        }

        [HttpGet]
        [Route("CommentById")]
        public IActionResult GetCommentByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();

            return Ok(value);
        }

        [HttpGet]
        [Route("ActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int value = _commentContext.UserComments.Where(x => x.IsActive == true).Count();

            return Ok(value);
        }

        [HttpGet]
        [Route("PasiveCommentCount")]
        public IActionResult GetPasiveCommentCount()
        {
            int value = _commentContext.UserComments.Where(x => x.IsActive == false).Count();

            return Ok(value);
        }

        [HttpGet]
        [Route("TotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            int value = _commentContext.UserComments.Count();

            return Ok(value);
        }
    }
}