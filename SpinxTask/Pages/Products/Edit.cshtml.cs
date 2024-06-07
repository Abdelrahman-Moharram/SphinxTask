using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Products
{
    public class EditModel : PageModel
    {

        private readonly IProductServices _productServices;

        [BindProperty]
        public ProductDTO product { get; set; }

        public BaseResponse response { get; set; }
        public EditModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public async void OnGet()
        {
            product = await _productServices.GetProduct(Id);
            
        }

        public async Task<IActionResult> OnPost(ProductDTO product)
        {
            if (ModelState.IsValid) 
            { 
                await _productServices.EditProduct(product);
                return Redirect($"/products");
            }
            return Page();

        }

    }
}
