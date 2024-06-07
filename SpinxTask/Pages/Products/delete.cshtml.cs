using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Products
{
    public class deleteModel : PageModel
    {
        private readonly IProductServices _productServices;

        public BaseResponse response { get; set; }
        public deleteModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            response = await _productServices.DeleteProduct(Id);

            return Redirect("/products");
        }
    }
}
