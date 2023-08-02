using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketFinance
{
    public class Sale : Customer
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public List<(int ProductId, int Quantity)> Products { get; set; }
        public decimal TotalAmount { get; set; }

        public Sale() 
        {
            SaleId = default!;
            Date = default!; 
            Products = default!;
            TotalAmount = default!;
        }

        public Sale(int saleId, DateTime date, List<(int ProductId, int Quantity)> products, decimal totalAmount)
        {
            SaleId = saleId;
            Date = date;
            Products = products;
            TotalAmount = totalAmount;
        }
    }
}
