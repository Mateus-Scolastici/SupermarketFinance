using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketFinance
{
    public class CashierSystem
    {
        private List<Customer> customers = new List<Customer>();
        private List<Product> products = new List<Product>();
        private List<Sale> sales = new List<Sale>();
        private int currentSaleID = 1;

        public void AddCustomer(string name)
        {
            int newCustomerID = customers.Count + 1;
            Customer customer = new Customer { CustomerId = newCustomerID, CustomerName = name };
            customers.Add(customer);
        }

        public void AddProduct(string name, decimal price, int stockquantity)
        {
            int newProductID = products.Count + 1;
            Product product = new Product { ProductId = newProductID, Name = name, Price = price, StockQuantity = stockquantity };
            products.Add(product);
        }

        public void ShowCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.CustomerName}");
            }
        }

        public void ShowProducts()
        {
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: ${product.Price}, Stock Quantity: {product.StockQuantity}");
            }
        }

        public void StartSale(int customerId)
        {
            Console.WriteLine($"Starting new sale for Customer ID: {customerId}");
            Console.WriteLine("Please enter the product ID and quantity (e.g., '1 3'), or type 'done' to finish the sale:");

            List<(int ProductId, int Quantity)> productsToSell = new List<(int, int)>();
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input) && input.ToLower() != "done")
            {
                string[] inputParts = input.Split(' ');
                if (inputParts.Length == 2 && int.TryParse(inputParts[0], out int productId) && int.TryParse(inputParts[1], out int quantity))
                {
                    Product product = products.Find(p => p.ProductId == productId);
                    if (product != null)
                    {
                        if (product.StockQuantity >= quantity)
                        {
                            productsToSell.Add((productId, quantity));
                            product.StockQuantity -= quantity;
                            Console.WriteLine($"Added {quantity} unit(s) of '{product.Name}' to the sale.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough stock for '{product.Name}'. Available: {product.StockQuantity}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Product with ID {productId} not found.");
                    }
                }
                else if (input?.ToLower() != "done")
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                input = Console.ReadLine();
            }

            decimal totalAmount = CalculateTotalAmount(productsToSell);
            Console.WriteLine($"Total amount: ${totalAmount}");

            Sale sale = new Sale
            {
                SaleId = currentSaleID,
                CustomerId = customerId,
                Date = DateTime.Now,
                Products = productsToSell,
                TotalAmount = totalAmount
            };
            sales.Add(sale);
            currentSaleID++;
        }

        private decimal CalculateTotalAmount(List<(int ProductId, int Quantity)> productsToSell)
        {
            decimal totalAmount = 0;
            foreach (var item in productsToSell)
            {
                Product product = products.Find(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    totalAmount += product.Price * item.Quantity;
                }
                else
                {
                    Console.WriteLine($"Product with ID {item.ProductId} not found.");
                }
            }
            return totalAmount;
        }

        public void ShowSalesReport()
        {
            Console.WriteLine("Sales Report:");
            foreach (var sale in sales)
            {
                Console.WriteLine($"Sale ID: {sale.SaleId}, Customer ID: {sale.CustomerId}, Date: {sale.Date}, Total Amount: ${sale.TotalAmount}");
                Console.WriteLine("Products sold:");
                foreach (var item in sale.Products)
                {
                    Product product = products.Find(p => p.ProductId == item.ProductId);
                    if (product != null)
                    {
                        Console.WriteLine($"{product.Name} - Quantity: {item.Quantity}, Subtotal: ${product.Price * item.Quantity}");
                    }
                    else
                    {
                        Console.WriteLine($"Product with ID {item.ProductId} not found.");
                    }
                }
                Console.WriteLine("-------------------------");
            }
        }
    }
}
