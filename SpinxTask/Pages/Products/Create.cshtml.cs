using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductServices _productServices;


        [BindProperty]
        public AddProductDTO newProductDTO { get; set; }

        public CreateModel(IProductServices productServices)
        {
           _productServices = productServices;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(AddProductDTO newProductDTO)
        {
            if (ModelState.IsValid)
            {
                var response = _productServices.AddProduct(newProductDTO);
                return Redirect("/products?size=10&p=1");
            }
            return Page();
        }
    }
}
