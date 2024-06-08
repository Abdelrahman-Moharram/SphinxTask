using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly IClientServices _clientServices;

        [BindProperty]
        public ClientDTO client { get; set; }
        public CreateViewModel createViewModel { get; set; }

        public BaseResponse res { get; set; }
        public EditModel(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }


        public async Task<IActionResult> OnGet(string Id)
        {
            
            
            createViewModel = await _clientServices.GetClassesAndStates();
            client = await _clientServices.GetClient(Id);

            return Page();

        }

        public async Task<IActionResult> OnPost(ClientDTO client, string Id)
        {
            createViewModel = await _clientServices.GetClassesAndStates();
            if (ModelState.IsValid)
            {
                res = await _clientServices.EditClient(client);
                if(res.IsSuccess)
                    return Redirect($"/clients");
                return Page();
            }
            return Page();

        }
    }
}
