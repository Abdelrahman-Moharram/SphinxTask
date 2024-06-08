using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.ClientProdutcs;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients.Details
{
    public class EditModel : PageModel
    {
        private readonly IProductServices _productServices;
        private readonly IClientServices _clientServices;

        public EditModel(IClientServices clientServices, IProductServices productServices)
        {
            _clientServices = clientServices;
            _productServices = productServices;
        }

        public List<BaseModule> ProductList { get; set; }
        public BaseResponse res { get; set; }

        [BindProperty]
        public FormClientProductDTO clientProduct { get; set; }





        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string productId { get; set; }
        public async Task OnGet(string Id, string productId)
        {
            ProductList = await _productServices.ListProductsBase();
            clientProduct = await _clientServices.GetClientProductForm(ClientId:Id, ProductId:productId);
        }


        public async Task<IActionResult> OnPost(FormClientProductDTO clientProduct, string Id, string productId)
        {
            ProductList = await _productServices.ListProductsBase();
            clientProduct.ClientId = Id;
            clientProduct.ProductId = productId;
            ModelState.Remove("clientProduct.ClientId");
            ModelState.Remove("clientProduct.ProductId");

            if (clientProduct.EndDate != null)
                if (clientProduct.StartDate.Date >= clientProduct.EndDate.Value.Date)
                    ModelState.AddModelError("clientProduct.EndDate", "Start Date is Greater than End Date");
            if (ModelState.IsValid)
            {
                res = await _clientServices.UdateClientProduct(clientProduct);
                if (res.IsSuccess)
                    return Redirect($"/clients/{Id}");
            }
            return Page();
        }
    }
}
