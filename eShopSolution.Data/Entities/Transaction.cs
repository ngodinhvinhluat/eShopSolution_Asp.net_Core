using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Transaction
    {
       public int ID                            {get;set;}
       public DateTime TransactionDate               {get;set;}
       public string ExternalTransactionID         {get;set;}
       public decimal Amount                        {get;set;}
       public decimal Fee                           {get;set;}
       public TransactionStatus Status                        {get;set;}
       public string Result                        {get;set;}
       public string Message                       {get;set;}
       public int Provider { get; set; }
    }
}
