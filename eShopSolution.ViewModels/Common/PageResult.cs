using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Common
{
    public class PageResult<T>
    {
        public List<T> Item { get; set; }
        public int TotalRecord { get; set; }
    }
}
