using System.ComponentModel.DataAnnotations;

namespace SpinxTask.Core.DTOs.ClientProdutcs
{
    public class FormClientProductDTO
    {
        public string ClientId { get; set; }
        public string ProductId { get; set; }
        
        
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [MaxLength(255)]
        public string License { get; set; }
        
    }
}
