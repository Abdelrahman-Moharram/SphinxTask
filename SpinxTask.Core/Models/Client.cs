using System.ComponentModel.DataAnnotations;

namespace SpinxTask.Core.Models
{
    public class Client
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();


        public string Name { get; set; }

        
        [RegularExpression(@"^[0-9]{9}$")]
        public string Code { get; set; }

        public string ClassId { get; set; }
        public Class Class { get; set; }


        public string StateId { get; set; }

        public State State { get; set; }
        public List<Product>? Products { get; set; }

        public List<ClientProduct>? ClientProducts { get; set; }

    }
}
