using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using eShopSolution.Application.Common;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDBContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(EShopDBContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> AddImages(int productID, List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var productImage = new ProductImage()
                {
                    DateCreate = DateTime.Now,
                    FileSize = file.Length,
                    ImagePath = await this.SaveFile(file),
                    IsDeafault = false,

                };
                _context.ProductImages.Add(productImage);
            }
            return _context.SaveChanges();
        }

        public async Task AddViewCount(int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice=request.OriginalPrice,
                Stock=request.Stock,
                ViewCount=0,
                DateCreated=DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name=request.Name,
                        Description=request.Description,
                        Detail=request.Detail,
                        SeoDescription=request.SeoDescription,
                        SeoAlias=request.SeoAlias,
                        SeoTitle=request.SeoTitle,
                        LanguageID=request.LanguageID
                    }
                }
           };
            //save image
            if(request.ThumbnailImage!=null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption ="ThumbmailImage",
                        DateCreate=DateTime.Now,
                        FileSize= request.ThumbnailImage.Length,
                        ImagePath=await this.SaveFile(request.ThumbnailImage),
                        IsDeafault=true,
                        SortOrder=1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null) throw new EShopException($"Cannot find product {productID}");
            var images = _context.ProductImages.Where(x => x.ProductID == productID);
            foreach(var img in images)
            {
                await _storageService.DeleteFileAsync(img.ImagePath);
            }


            _context.Products.Remove(product);
           return await _context.SaveChangesAsync();

        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetManagePagingProductRequest request)
        {
            //select data
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductID
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductID
                        join c in _context.Categories on pic.CategoryID equals c.ID
                        select new { p, pt, c };
            //filter
            if(string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            }    
            if(request.CategoryIDs.Count>0)
            {
                query = query.Where(p => request.CategoryIDs.Contains(p.c.ID));
            }
            //paging
            int totalrow = await query.CountAsync();
            var  data = await query.Skip((request.PageIndex - 1) * request.PageSize).
                Take(request.PageSize).Select(x => new ProductViewModel()
                {
                    ID = x.p.ID,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Detail = x.pt.Detail,
                    LanguageID = x.pt.LanguageID,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }
                ).ToListAsync();
            //select and projection
            var pageresult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalrow,
                Item = data
            };
            return pageresult;
        }

        public async Task<List<ProductImageViewModel>> GetListImage(int productID)
        {
            var images = _context.ProductImages.Where(x => x.ProductID == productID)
                .Select(i => new ProductImageViewModel()
                {
                    ID = i.ID,
                    FilePath = i.ImagePath,
                    FileSize = i.FileSize,
                    Isdefault = i.IsDeafault
                }
                ).ToListAsync();

            return await images;
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var images = await _context.ProductImages.FindAsync(imageId);
            
                await _storageService.DeleteFileAsync(images.ImagePath);
            _context.Remove(images);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTrans = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductID == request.Id&&x.LanguageID==request.LanguageID);
                if (product == null||productTrans==null) throw new EShopException($"Cannot find a product with ID: {request.Id}");
            productTrans.Name = request.Name;
            productTrans.SeoAlias = request.SeoAlias;
            productTrans.SeoDescription = request.SeoDescription;
            productTrans.SeoTitle = request.SeoTitle;
            productTrans.Description = request.Description;
            productTrans.Detail = request.Detail;
            //Update image
            if(request.ThumbnailImage!=null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDeafault == true && i.ProductID == request.Id);
                if(thumbnailImage!=null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync(); 

        }

        public async Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            var images = await _context.ProductImages.FindAsync(imageId);
            images.Caption = caption;
            if(isDefault)
            {
                var imgs = _context.ProductImages.Where(x => x.ProductID == images.ProductID);
                foreach(var img in imgs)
                {
                    img.IsDeafault = false;
                }
            }
            images.IsDeafault = isDefault;
            _context.Update(images);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productID, decimal NewPrice)
        {
            var prduct = await _context.Products.FindAsync(productID);
            if (prduct == null) throw new EShopException($"Cannot find product with ID: {productID}");
            prduct.Price = NewPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productID, int AddQuantity)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null) throw new EShopException($"Cannot find product with ID: {productID}");
            product.Stock += AddQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
