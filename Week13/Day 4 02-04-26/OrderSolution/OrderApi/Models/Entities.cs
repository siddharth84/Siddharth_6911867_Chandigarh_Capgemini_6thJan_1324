namespace OrderApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public UserProfile? Profile { get; set; }
        public List<Order> Orders { get; set; } = new();
    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User? User { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "Pending";

        public int UserId { get; set; }
        public User? User { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public List<ProductCategory> ProductCategories { get; set; } = new();
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ProductCategory> ProductCategories { get; set; } = new();
    }

    // Join table for many-to-many
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
