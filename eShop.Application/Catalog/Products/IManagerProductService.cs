
using eShop.ViewModels.Catalog.Common;
using eShop.ViewModels.Catalog.Product;

using eShop.ViewModels.Catalog.ProductImage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace eShop.Application.Catalog.Products
{
    public interface IManagerProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId,decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

      

    }
}
