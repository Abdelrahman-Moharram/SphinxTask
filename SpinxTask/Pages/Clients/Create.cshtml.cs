using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly IClientServices _clientServices;

        public BaseResponse res { get; set; }

        [BindProperty]
        public BaseClientDTO newClientDTO { get; set; }

        public CreateViewModel createViewModel {  get; set; }
        public CreateModel(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        public async Task OnGet()
        {
            createViewModel = await _clientServices.GetClassesAndStates();
        }

        public async Task<IActionResult> OnPost(BaseClientDTO newClientDTO)
        {
            if (ModelState.IsValid)
            {
                res = await _clientServices.AddClient(newClientDTO);
                if (res.IsSuccess)
                    return Redirect("/Clients?size=10&p=1");
            }
            createViewModel = await _clientServices.GetClassesAndStates();
            return Page();
        }
    }
    
}
