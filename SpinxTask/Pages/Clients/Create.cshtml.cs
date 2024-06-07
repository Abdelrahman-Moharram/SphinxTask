using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly IClientServices _clientServices;


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
                var response = _clientServices.AddClient(newClientDTO);
                return Redirect("/Clients?size=10&p=1");
            }
            createViewModel = await _clientServices.GetClassesAndStates();
            return Page();
        }
    }
    
}
