class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "742 Evergreen Terrace",
            "Springfield",
            "Oregon",
            "USA"
        );
        Customer customer1 = new Customer("Jordan Miller", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-204", 24.99, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "MK-310", 69.50, 1));
        order1.AddProduct(new Product("USB-C Cable", "UC-115", 9.75, 3));

        Address address2 = new Address(
            "18 King Street West",
            "Toronto",
            "Ontario",
            "Canada"
        );
        Customer customer2 = new Customer("Amelia Chen", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Insulated Water Bottle", "WB-440", 18.95, 2));
        order2.AddProduct(new Product("Canvas Backpack", "BP-225", 42.00, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        for (int i = 0; i < orders.Count; i++)
        {
            Order order = orders[i];

            Console.WriteLine($"ORDER {i + 1}");
            Console.WriteLine();
            Console.WriteLine("PACKING LABEL");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine("SHIPPING LABEL");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.CalculateTotalPrice():F2}");
            Console.WriteLine();
        }
    }
}
