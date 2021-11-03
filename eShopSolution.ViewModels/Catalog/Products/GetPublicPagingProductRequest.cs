using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetPublicPagingProductRequest : PagingRequestBase
    {
        public int? CategoryID { get; set; }
    }
}
