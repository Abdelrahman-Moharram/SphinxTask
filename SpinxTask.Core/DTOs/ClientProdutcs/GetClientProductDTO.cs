namespace SpinxTask.Core.DTOs.ClientProdutcs
{
    public class GetClientProductDTO
    {
        public BaseModule Product { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string License { get; set; }
    }
}
