using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.IServices;

namespace SpinxTask.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductServices _productServices;

        [BindProperty(SupportsGet = true)]
        public int Size { get; set; }

        [BindProperty(SupportsGet = true)]
        public int P { get; set; }
        public List<ProductDTO> products { get; set; } = new List<ProductDTO>();
        public int length { get; set; }
        /*public int PagesLength { get; set; }*/
        public IndexModel(IProductServices productServices)
        {
            _productServices = productServices;
            
        }

        
        public async Task<IActionResult> OnGet()
        {
            this.P = P;
            this.Size = Size;
            if (Size <= 0 || P <= 0)
            {
                return Redirect("/products?size=10&p=1");
            }
            products = await _productServices.ListProducts(take: this.Size, skip: (this.P - 1) * this.Size);
            length = await _productServices.ProductsLength() / Size;
            return Page();
        }
    }
}
