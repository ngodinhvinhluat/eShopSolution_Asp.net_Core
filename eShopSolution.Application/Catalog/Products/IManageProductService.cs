using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public  interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productID);
        Task<bool> UpdatePrice(int productID, decimal NewPricr);
        Task<bool> UpdateStock(int productID, int AddQuantity);
        Task AddViewCount(int productID);
        Task<List<ProductViewModel>> GetAll();
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManagePagingProductRequest request);
        Task<int> AddImages(int productID, List<IFormFile> files);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, string caption, bool isDefault);
        Task<List<ProductImageViewModel>> GetListImage(int productID);
        
    }
}
