using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients.Details
{
    public class DeleteModel : PageModel
    {
        private readonly IClientServices _clientServices;

        public DeleteModel(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string productId { get; set; }


        public BaseResponse res { get; set; }
        public async Task<IActionResult> OnGet(string Id, string productId)
        {
            if (productId == null || Id == null)
            {
                res = new BaseResponse
                {
                    Message = "Invalid Client Or Product Data"
                };

                return Redirect($"/clients/{Id}");
            }
            await _clientServices.DeleteClientProduct(ProductId: productId, ClientId: Id);

            return Redirect($"/clients/{Id}");



        }
    }
}
