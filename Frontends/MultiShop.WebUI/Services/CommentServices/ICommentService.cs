using MultiShop.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService : IGenericService<ResultCommentDto, CreateCommentDto, UpdateCommentDto>
    {
        Task<List<ResultCommentDto>> GetCommentByProductId(string id);
    }
}
