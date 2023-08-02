using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketFinance
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Product() 
        {
            ProductId = default!;
            Name = default!;
            Price = default!;
            StockQuantity = default!;
        }

        public Product(int productId, string name, decimal price, int stockQuantity)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }
}
