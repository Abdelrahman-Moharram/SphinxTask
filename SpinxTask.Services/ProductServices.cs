using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.DTOs.Products;
using SpinxTask.Core.Interfaces;
using SpinxTask.Core.IServices;
using SpinxTask.Core.Models;

namespace SpinxTask.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<BaseModule>> ListProductsBase()
        {
            var products =
                await _unitOfWork
                    .Products
                    .FindAllAsync(
                        i => i.IsActive,
                        orderBy: i => i.OrderBy(p => p.Name)
                    );
            return _mapper.Map<List<BaseModule>>(products);
        }
        public async Task<List<ProductDTO>> ListProducts(int take, int skip)
        {
            var products = 
                await _unitOfWork
                    .Products
                    .GetAllAsync(
                        orderBy:i=>i.OrderBy(p=>p.Name), 
                        take:take, 
                        skip:skip
                    );
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProduct(string Id)
        {
            var products =
                await _unitOfWork
                    .Products
                    .GetById(Id);

            return _mapper.Map<ProductDTO>(products);
        }

        public async Task<int> ProductsLength()
        {
            var length =
                await _unitOfWork
                    .Products
                    .GetCount();

            return length;
        }


        public async Task<BaseResponse> AddProduct(AddProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _unitOfWork.Products.AddAsync(product);
            _unitOfWork.SaveAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "Product Added Successfully"
            };
            
        }

        public async Task<BaseResponse> EditProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            if (product == null)
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "This Product is not found"
                };
            await _unitOfWork.Products.UpdateAsync(product);
            _unitOfWork.SaveAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "Product Added Successfully"
            };

        }

        public async Task<BaseResponse> DeleteProduct(string Id)
        {
            var product = await _unitOfWork.Products.FindAsync(i=>i.Id == Id, include:i=>i.Include(p=>p.ClientProducts));

            if (product == null)
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "This Product is not found"
                };
            if(product.ClientProducts.Count() > 0)
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "This Product can't be deleted because it related with some clients product instances"
                };
            _unitOfWork.Products.DeleteAsync(product);
            _unitOfWork.SaveAsync();
            return new BaseResponse
            {
                IsSuccess = true,
                Message = $"Product {product.Name} Deleted Successfully"
            };
        }
    }
}
