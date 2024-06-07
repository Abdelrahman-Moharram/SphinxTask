using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly IClientServices _clientServices;

        public IndexModel(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [BindProperty(SupportsGet = true)]
        public int Size { get; set; }

        [BindProperty(SupportsGet = true)]
        public int P { get; set; }

        public List<GetClientDTO> clients { get; set; } = new List<GetClientDTO>();
        public int length { get; set; }
        public async Task<IActionResult> OnGet()
        {
            this.P = P;
            this.Size = Size;
            if (Size <= 0 || P <= 0)
            {
                return Redirect("/clients?size=10&p=1");
            }
            clients = await _clientServices.ListClients(take: this.Size, skip: (this.P - 1) * this.Size);
            length = await _clientServices.ClientsLength() / Size;
            return Page();
        }
    }
}
