using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;
using SpinxTask.Core.DTOs.Clients;

namespace SpinxTask.Pages.Clients.Details
{
    public class IndexModel : PageModel
    {
        private readonly IClientServices _clientServices;
        public GetClientDTO client { get; set; }

        public BaseResponse response { get; set; }
        public IndexModel(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public async Task<IActionResult> OnGet(string Id)
        {
            if (Id == null)
                return NotFound();

            client = await _clientServices.GetClient(Id);
            return Page();
        }

    }
}
