using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketFinance
{
    public class Customer 
    { 
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Customer()
        {
            CustomerId = default!;
            CustomerName = default!;
        }

        public Customer(int customerId, string customerName)
        {
            CustomerId = customerId;
            CustomerName = customerName;
        }
    }
}
