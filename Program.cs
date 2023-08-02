namespace SupermarketFinance
{
    public class Program
    {
        static void Main(string[] args)
        {
            CashierSystem cashierSystem = new CashierSystem();

            // Adicionar alguns clientes
            cashierSystem.AddCustomer("John Doe");
            cashierSystem.AddCustomer("Jane Smith");

            // Adicionar alguns produtos
            cashierSystem.AddProduct("Banana", 2.5m, 20);
            cashierSystem.AddProduct("Apple", 1.8m, 15);
            cashierSystem.AddProduct("Milk", 3.0m, 10);
            cashierSystem.AddProduct("Bread", 2.2m, 30);

            // Exibir clientes cadastrados
            cashierSystem.ShowCustomers();

            // Exibir produtos disponíveis
            cashierSystem.ShowProducts();

            // Realizar vendas
            cashierSystem.StartSale(1); // Customer ID: 1
            cashierSystem.StartSale(2); // Customer ID: 2

            // Exibir relatório de vendas
            cashierSystem.ShowSalesReport();
        }
    }
}