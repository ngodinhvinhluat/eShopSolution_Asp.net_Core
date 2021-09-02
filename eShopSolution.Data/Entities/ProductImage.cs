using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductImage
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ImagePath { get; set;}
        public string Caption { get; set; }
        public bool IsDeafault { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
        public Product Product { get; set; }
    }
}
