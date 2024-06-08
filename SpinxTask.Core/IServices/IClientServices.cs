
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.ClientProdutcs;

namespace SpinxTask.Core.IServices
{
    public interface IClientServices
    {
        Task<List<GetClientDTO>> ListClients(int take, int skip);
        Task<GetClientDTO> GetClient(string Id);
        Task<BaseResponse> AddClient(BaseClientDTO ClientDTO);
        Task<int> ClientsLength();
        Task<CreateViewModel> GetClassesAndStates();
        Task<BaseResponse> DeleteClient(string Id);
        Task<BaseResponse> EditClient(ClientDTO ClientDTO);
        Task<FormClientProductDTO> GetClientProductForm(string ClientId, string ProductId);
        Task<BaseResponse> AddClientProduct(FormClientProductDTO clientProduct);

        Task<BaseResponse> UdateClientProduct(FormClientProductDTO clientProductDTO);
        Task<BaseResponse> DeleteClientProduct(string ClientId, string ProductId);

    }
}
