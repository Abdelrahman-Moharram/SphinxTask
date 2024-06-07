using SpinxTask.Core.DTOs.ClientProdutcs;

namespace SpinxTask.Core.DTOs.Clients
{
    public class GetClientDTO : ClientDTO
    {
        public string StateName { get; set; }
        public string ClassName { get; set; }

        public List<GetClientProductDTO>? ClientProducts  { get; set; }
    }
}