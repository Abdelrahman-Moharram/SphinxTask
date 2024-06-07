
using System.ComponentModel.DataAnnotations;

namespace SpinxTask.Core.DTOs.Products
{
    public class AddProductDTO 
    {
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(150)]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
