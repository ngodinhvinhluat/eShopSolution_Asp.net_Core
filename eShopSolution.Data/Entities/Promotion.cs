using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Promotion
    {
        public int ID { get; set; }
        public DateTime FromDate                     {get;set;}
        public DateTime ToDate                       {get;set;}
        public bool ApplyForAll                  {get;set;}
        public int? DiscountPercent              {get;set;}
        public int? DiscountAmount               {get;set;}
        public string ProductIDs                   {get;set;}
        public string ProductCategoryIDs           {get;set;}
        public Status Status                       {get;set;}
        public string Name                         {get;set;}
    }
}
