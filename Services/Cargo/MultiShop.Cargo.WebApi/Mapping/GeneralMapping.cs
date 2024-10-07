using AutoMapper;
using MultiShop.Cargo.Dtos.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Dtos.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Dtos.Dtos.CargoDetailDtos;
using MultiShop.Cargo.Dtos.Dtos.CargoOperationDtos;
using MultiShop.Cargo.Entities.Concrete;

namespace MultiShop.Cargo.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CargoCompany, GetCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();

            CreateMap<CargoCustomer, GetCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();

            CreateMap<CargoDetail, GetCargoDetailDto>()
                .ForPath(dest => dest.GetCargoCompanyDto.CargoCompanyName, opt => opt.MapFrom(src => src.CargoCompany.CargoCompanyName))
                .ForPath(dest => dest.GetCargoCompanyDto.CargoCompanyId, opt => opt.MapFrom(src => src.CargoCompany.CargoCompanyId))
                .ReverseMap();
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();

            CreateMap<CargoOperation, GetCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();
        }
    }
}
