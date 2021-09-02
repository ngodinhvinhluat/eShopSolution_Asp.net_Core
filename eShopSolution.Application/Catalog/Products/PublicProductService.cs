using eShopSolution.Data.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService :IPublicProductService
    {
       
        private readonly EShopDBContext _context;
        public PublicProductService(EShopDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductID
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductID
                        join c in _context.Categories on pic.CategoryID equals c.ID
                        select new { p, pt, c };
            var data = await query.Select(x => new ProductViewModel()
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
            
            return data;
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryID(GetPublicPagingProductRequest request)
        {
            //select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductID
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductID
                        join c in _context.Categories on pic.CategoryID equals c.ID
                        select new { p, pt, c };
            //filter
            if(request.CategoryID.HasValue && request.CategoryID.Value>0)
            {
                query = query.Where(p => p.c.ID == request.CategoryID);
            }
            //paging
            int totalrow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
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
            var pageresult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalrow,
                Item = data
            };
            return pageresult;
        }
    }
    
}
