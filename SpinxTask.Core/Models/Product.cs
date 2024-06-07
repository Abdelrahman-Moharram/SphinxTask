namespace SpinxTask.Core.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();


        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public List<Client> Clients { get; set; }
        public List<ClientProduct> ClientProducts { get; set; }


    }
}
