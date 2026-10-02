using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------------------------------------------
        // ORDER 1: USA Customer
        // -------------------------------------------------------------
        Address address1 = new Address("123 Main Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-101", 19.99m, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "MK-202", 79.50m, 1));
        order1.AddProduct(new Product("USB-C Cable", "UC-303", 8.25m, 3));

        // Display Details for Order 1
        Console.WriteLine("========================================");
        Console.WriteLine("                ORDER 1                 ");
        Console.WriteLine("========================================\n");
        
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order1.GetPackingLabel());
        
        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"TOTAL PRICE: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n");

        // -------------------------------------------------------------
        // ORDER 2: Non-USA Customer
        // -------------------------------------------------------------
        Address address2 = new Address("456 Rizal Avenue", "Manila", "Metro Manila", "Philippines");
        Customer customer2 = new Customer("Maria Santos", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Gaming Monitor 27\"", "GM-404", 249.99m, 1));
        order2.AddProduct(new Product("HDMI Cable 6ft", "HC-505", 12.00m, 2));

        // Display Details for Order 2
        Console.WriteLine("========================================");
        Console.WriteLine("                ORDER 2                 ");
        Console.WriteLine("========================================\n");
        
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order2.GetPackingLabel());
        
        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"TOTAL PRICE: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("========================================");
    }
}

// =====================================================================
// CLASS DEFINITIONS
// =====================================================================

/// <summary>
/// Represents a single product with its details and cost computation.
/// </summary>
public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName() => _name;
    public string GetProductId() => _productId;
    public decimal GetPrice() => _price;
    public int GetQuantity() => _quantity;

    /// <summary>
    /// Computes total cost for this product line item.
    /// </summary>
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}

/// <summary>
/// Represents a street address and determines if it is located within the USA.
/// </summary>
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    /// <summary>
    /// Checks whether the address country is in the USA.
    /// </summary>
    public bool IsInUSA()
    {
        return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               _country.Trim().Equals("United States", StringComparison.OrdinalIgnoreCase) ||
               _country.Trim().Equals("US", StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Formats all address fields into a multi-line display string.
    /// </summary>
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}

/// <summary>
/// Represents a customer containing a name and an Address object.
/// </summary>
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;
    public Address GetAddress() => _address;

    /// <summary>
    /// Delegates checking USA residence to the Address object.
    /// </summary>
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}

/// <summary>
/// Manages a list of products for a customer, calculating shipping and total costs.
/// </summary>
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    /// <summary>
    /// Calculates total order cost including shipping charges based on location.
    /// </summary>
    public decimal CalculateTotalCost()
    {
        decimal productTotal = 0m;
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA() ? 5.00m : 35.00m;
        return productTotal + shippingCost;
    }

    /// <summary>
    /// Generates packing label displaying Name and ID for each product.
    /// </summary>
    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"• {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label.TrimEnd();
    }

    /// <summary>
    /// Generates shipping label with customer name and full address.
    /// </summary>
    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}