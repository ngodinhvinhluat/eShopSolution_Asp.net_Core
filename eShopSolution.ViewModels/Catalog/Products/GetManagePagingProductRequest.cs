using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetManagePagingProductRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIDs { get; set; }
    }
}
