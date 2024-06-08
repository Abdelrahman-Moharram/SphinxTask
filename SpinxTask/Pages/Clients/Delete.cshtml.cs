using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly IClientServices _clientServices;
        public BaseResponse response { get; set; }
        public DeleteModel(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }


        public async Task<IActionResult> OnGet(string Id)
        {
            response = await _clientServices.DeleteClient(Id);

            return Redirect("/clients");
        }
    }
}
