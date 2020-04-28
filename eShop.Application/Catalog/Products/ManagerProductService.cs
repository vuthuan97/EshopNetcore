
using eShop.Data.EF;
using eShop.Data.Entites;
using eShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using eShop.ViewModels.Catalog.Product;
using eShop.ViewModels.Catalog.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using eShop.Application.Common;
using eShop.ViewModels.Catalog.ProductImage;

namespace eShop.Application.Catalog.Products
{
    public class ManagerProductService : IManagerProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManagerProductService(EShopDbContext context, IStorageService storageService)
        {
            this._context = context;
            this._storageService = storageService;
        }

        public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task AddViewCount(int productId)
        {
            var product =  await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
           await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreate = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation
                    {
                        Name= request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        SeoAlias = request.SeoAlias,
                        LanguageId = request.LanguageId
                    }
                }
                
                

            };
            //save image
            if(request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage(){
                    Caption = "thumbail Image",
                    DateCreated = DateTime.Now,
                    FileSize =request.ThumbnailImage.Length,
                    ImagePath = await this.SaveFile(request.ThumbnailImage),
                IsDefault = true,
                    SortOrder =1

                    }
                };
            }
            _context.Products.Add(product);
          return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int productId)
        {
            var pro = await _context.Products.FindAsync(productId);
            if (pro == null) throw new eShopException($"can't find product :{productId}");
            var images =  _context.ProductImages.Where(i =>i.ProductId == productId);
            foreach(var item in images)
            {
              await _storageService.DeleteFileAsync(item.ImagePath);
            }
            _context.Products.Remove(pro);
            
            
           return await _context.SaveChangesAsync();
        }

       
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1 select join
            var query = from p in _context.Products

                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            //2.filter        select new {p,pt,pic };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(c => c.pt.Name.Contains(request.Keyword));
            }
            if(request.CategoryIds.Count() > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //3.paging
            int totalrow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x=>new ProductViewModel() {
                    Id= x.p.Id,
                    Name = x.pt.Name,
                    DateCreate = x.p.DateCreate,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias =x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                    

                }).ToListAsync();

            //4. select in project
            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalrow,
                Items = data
            };
            return pageResult;
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null)
                throw new eShopException($"Cannot find an image with id {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _context.ProductImages.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductId = i.ProductId,
                    SortOrder = i.SortOrder
                }).ToListAsync();
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new eShopException($"Cannot find an image with id {imageId}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var pro = await _context.Products.FindAsync(request.Id);
            var proTran = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id &&
                                                                                x.LanguageId==request.LanguageId);
            if (pro == null || proTran==null) throw new eShopException($"can't not find product width id:{request.Id} ");
            proTran.Name = request.Name;
            proTran.Description = request.Description;
            proTran.Details = request.Details;
            proTran.SeoAlias = request.SeoAlias;
            proTran.SeoDescription = request.SeoDescription;
            proTran.SeoTitle = request.SeoTitle;
            //save image
            if (request.ThumbnailImage != null)
            {
                var thumbailimage =  await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if(thumbailimage != null)
                {
                   
                    thumbailimage.FileSize = request.ThumbnailImage.Length;
                    thumbailimage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbailimage);
                }
                
            }

            return await _context.SaveChangesAsync();

             

        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new eShopException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var pro = await _context.Products.FindAsync(productId);
            if (pro == null) throw new eShopException($"can't not find Product width {productId}");
            pro.Price = newPrice;
           return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var pro = await _context.Products.FindAsync(productId);
            if (pro == null) throw new eShopException($"can't not find Product width {productId}");
            pro.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var OriginalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(OriginalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;

        }
    }
}
