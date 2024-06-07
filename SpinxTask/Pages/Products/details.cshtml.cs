using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Products
{
    public class detailsModel : PageModel
    {
        private readonly IProductServices _productServices;
        public ProductDTO product {  get; set; }

        public BaseResponse response { get; set; }
        public detailsModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (Id == null) 
            {
                return NotFound();
            }
            product = await _productServices.GetProduct(Id);
            return Page();
        }

    }
}
