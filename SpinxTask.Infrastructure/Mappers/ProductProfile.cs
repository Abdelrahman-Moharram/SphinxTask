using AutoMapper;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.Models;

namespace SpinxTask.Infrastructure.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<AddProductDTO, Product>()
                .ReverseMap();

            CreateMap<BaseModule, Product>()
            .ReverseMap();

            CreateMap<ProductDTO, Product>()
                .ReverseMap();
        }
    }
}
