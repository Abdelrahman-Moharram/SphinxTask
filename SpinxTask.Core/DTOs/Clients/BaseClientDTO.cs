using System.ComponentModel.DataAnnotations;

namespace SpinxTask.Core.DTOs.Clients
{
    public class BaseClientDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Code Must be 9 Unique Numbers")]
        public string Code { get; set; }

        public string ClassId { get; set; }

        public string StateId { get; set; }
    }
}
