using AutoMapper;
using SpinxTask.Core.DTOs.ClientProdutcs;
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.Models;

namespace SpinxTask.Infrastructure.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<BaseClientDTO, Client>();

            CreateMap<ClientDTO, Client>()
                .ReverseMap();
            
            CreateMap<Client, GetClientDTO>()
                .ForMember(dest=>dest.ClassName, opt=>opt.MapFrom(src=>src.Class.Name))
                .ForMember(dest=>dest.StateName, opt=>opt.MapFrom(src=>src.State.Name))
                .ForMember(dest=>dest.ClientProducts, opt=>opt.MapFrom(src=> 
                    src.ClientProducts.Select(CP=>new GetClientProductDTO
                    {
                        EndDate = CP.EndDate,
                        License = CP.License,
                        StartDate = CP.StartDate,
                        Product = new Core.DTOs.BaseModule { Id = CP.ProductId, Name = CP.Product.Name }
                    }
                )))
                .ReverseMap();

        }
    }
}
