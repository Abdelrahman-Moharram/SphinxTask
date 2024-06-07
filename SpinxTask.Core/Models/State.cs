
namespace SpinxTask.Core.Models
{
    public class State
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<Client>? Clients { get; set; }

    }
}
