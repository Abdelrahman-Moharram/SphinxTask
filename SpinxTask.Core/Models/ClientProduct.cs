
namespace SpinxTask.Core.Models
{
    public class ClientProduct
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string License { get; set; }

    }
}
