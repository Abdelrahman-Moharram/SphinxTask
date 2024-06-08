using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.IServices;
using SpinxTask.Core.Models;
using SpinxTask.Services;

namespace SpinxTask.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductServices _productServices;

        public BaseResponse res {  get; set; }

        [BindProperty]
        public AddProductDTO newProductDTO { get; set; }

        public CreateModel(IProductServices productServices)
        {
           _productServices = productServices;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(AddProductDTO newProductDTO)
        {
            if (ModelState.IsValid)
            {
                res = await _productServices.AddProduct(newProductDTO);
                if (res.IsSuccess)
                    return Redirect("/products?size=10&p=1");
            }
            return Page();
        }
    }
}
