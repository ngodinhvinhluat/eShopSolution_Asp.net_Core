using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class CategoryTranslation
    {
        public int Id                     {get;set;}
        public int CategoryID             {get;set;}
        public string Name                   {get;set;}
        public string SeoDescription         {get;set;}
        public string SeoTitle               {get;set;}
        public string SeoAlias               {get;set;}
        public string  LanguageID { get; set; }
        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}
