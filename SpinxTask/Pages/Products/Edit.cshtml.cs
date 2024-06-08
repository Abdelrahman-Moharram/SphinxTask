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
        public BaseResponse res {  get; set; }

        /*[BindProperty(SupportsGet = true)]
        public string Id { get; set; }*/
        public async void OnGet(string Id)
        {
            product = await _productServices.GetProduct(Id);
            
        }

        public async Task<IActionResult> OnPost(ProductDTO product, string Id)
        {
            if (ModelState.IsValid) 
            { 
                res = await _productServices.EditProduct(product);
                if (res.IsSuccess)
                    return Redirect($"/products");
            }
            return Page();

        }

    }
}
