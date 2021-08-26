using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Contact
    {
        public int ID                {get;set;}
        public string Name              {get;set;}
        public string Email             {get;set;}
        public string PhoneNumber       {get;set;}
        public string Message           {get;set;}
        public Status Status { get; set; }
    }
}
