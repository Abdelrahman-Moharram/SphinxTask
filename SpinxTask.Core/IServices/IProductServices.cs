using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.Products;

namespace SpinxTask.Core.IServices
{
    public interface IProductServices
    {
        Task<List<ProductDTO>> ListProducts(int take, int skip);
        Task<List<BaseModule>> ListProductsBase();
        Task<ProductDTO> GetProduct(string Id);
        Task<BaseResponse> AddProduct(AddProductDTO productDTO);
        Task<int> ProductsLength();

        Task<BaseResponse> DeleteProduct(string Id);
        Task<BaseResponse> EditProduct(ProductDTO productDTO);
    }
}
