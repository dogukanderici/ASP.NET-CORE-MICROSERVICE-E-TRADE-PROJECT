using System.Linq.Expressions;

namespace MultiShop.WebUI.Services.CargoServices.CargoGenericServices
{
    public interface IGenericService<TResultDto, TCreateDto, TUpdateDto>
        where TResultDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<List<TResultDto>> TGetAllAsync(Guid? barcode);
        Task<TUpdateDto> TGetByFilterAsync(int id);
        Task TAddAsync(TCreateDto createDto);
        Task TUpdateAsync(TUpdateDto updateDto);
        Task TDeleteAsync(int id);
    }
}
