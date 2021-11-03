using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductImageViewModel
    {
        public int ID { get; set; }
        public string FilePath { get; set; }
        public bool Isdefault { get; set; }
        public long FileSize { get; set; }
    }
}
