using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceSystem
{
    public abstract class Product
    {
        public string ID { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; private set; }

        public Product(string id, string name, decimal price, int stock)
        {
            ID = id;
            Name = name;
            Price = price;
            StockQuantity = stock;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= StockQuantity)
                StockQuantity -= quantity;
            else
                Console.WriteLine($"Insufficient stock for {Name}!");
        }

        public abstract void DisplayInfo();
    }

    public class Electronics : Product
    {
        public int WarrantyMonths { get; set; }

        public Electronics(string id, string name, decimal price, int stock, int warranty)
            : base(id, name, price, stock)
        {
            WarrantyMonths = warranty;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Electronics] {Name} | Price: ${Price} | Warranty: {WarrantyMonths} months | Stock: {StockQuantity}");
        }
    }

    public class Clothing : Product
    {
        public string Size { get; set; }

        public Clothing(string id, string name, decimal price, int stock, string size)
            : base(id, name, price, stock)
        {
            Size = size;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Clothing] {Name} | Price: ${Price} | Size: {Size} | Stock: {StockQuantity}");
        }
    }

    public class ShoppingCart
    {
        private List<Product> items = new List<Product>();

        public void AddToCart(Product product)
        {
            if (product.StockQuantity > 0)
            {
                items.Add(product);
                product.ReduceStock(1);
                Console.WriteLine($"{product.Name} added to cart.");
            }
        }

        public decimal CalculateTotal() => items.Sum(p => p.Price);

        public void ShowCart()
        {
            Console.WriteLine("\n--- Your Shopping Cart ---");
            foreach (var item in items) Console.WriteLine($"- {item.Name}: ${item.Price}");
            Console.WriteLine($"Total: ${CalculateTotal()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new List<Product>
            {
                new Electronics("E001", "Smartphone", 699.99m, 10, 24),
                new Clothing("C001", "Cotton T-Shirt", 19.99m, 50, "L"),
                new Electronics("E002", "Laptop", 1200.00m, 5, 12)
            };

            ShoppingCart myCart = new ShoppingCart();

            Console.WriteLine("Welcome to the Store! Catalog:");
            foreach (var p in catalog) p.DisplayInfo();

            Console.WriteLine("\nAdding items to cart...");
            myCart.AddToCart(catalog[0]); 
            myCart.AddToCart(catalog[1]); 

            myCart.ShowCart();

            Console.WriteLine("\nUpdated Stock for Smartphone:");
            catalog[0].DisplayInfo();

            Console.ReadKey();
        }
    }
}
