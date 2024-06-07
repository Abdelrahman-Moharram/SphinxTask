using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Clients.Details
{
    public class CreateModel : PageModel
    {
        private readonly IProductServices _productServices;
        public List<BaseModule> ProductList { get; set; }
        public CreateModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task OnGet()
        {
            ProductList = await _productServices.ListProductsBase();
        }
    }
}
