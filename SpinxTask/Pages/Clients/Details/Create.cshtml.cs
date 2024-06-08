using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.ClientProdutcs;
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.IServices;
using SpinxTask.Core.Models;

namespace SpinxTask.Pages.Clients.Details
{
    public class CreateModel : PageModel
    {
        public CreateModel(IProductServices productServices, IClientServices clientServices)
        {
            _productServices = productServices;
            _clientServices = clientServices;
        }

        private readonly IProductServices _productServices;
        private readonly IClientServices _clientServices;
        public List<BaseModule> ProductList { get; set; }
        public BaseResponse res { get; set; }

        [BindProperty]
        public FormClientProductDTO clientProduct { get; set; }



        
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public async Task OnGet(string Id)
        {
            ProductList = await _productServices.ListProductsBase();
        }

        
        public async Task<IActionResult> OnPost(FormClientProductDTO clientProduct, string Id)
        {
            ProductList = await _productServices.ListProductsBase();
            clientProduct.ClientId = Id;
            ModelState.Remove("clientProduct.ClientId");
            if (clientProduct.EndDate != null)
                if (clientProduct.StartDate.Date >= clientProduct.EndDate.Value.Date)
                    ModelState.AddModelError("clientProduct.EndDate", "Start Date is Greater than End Date");
            if (ModelState.IsValid) 
            { 
                res = await _clientServices.AddClientProduct(clientProduct);
                if (res.IsSuccess)
                    return Redirect($"/clients/{Id}");
            }
            return Page();
        }
    }
}
