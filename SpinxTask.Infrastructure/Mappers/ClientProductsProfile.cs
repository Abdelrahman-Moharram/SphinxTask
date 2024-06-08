using AutoMapper;
using SpinxTask.Core.Models;

namespace SpinxTask.Core.DTOs.ClientProdutcs
{
    public class ClientProductsProfile : Profile
    {
        public ClientProductsProfile() 
        {
            CreateMap<ClientProduct, FormClientProductDTO>().ReverseMap();
        }
    }
}
