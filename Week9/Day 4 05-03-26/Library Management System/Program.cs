using System;
using System.Collections.Generic;
using System.Linq;

public interface IRealEstateListing
{
    int ID { get; set; }
    string Title { get; set; }
    string Description { get; set; }
    int Price { get; set; }
    string Location { get; set; }
}

public class RealEstateListing : IRealEstateListing
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Location { get; set; }
}

public class RealEstateApp
{
    private List<IRealEstateListing> listings = new List<IRealEstateListing>();

    public void AddListing(IRealEstateListing listing) => listings.Add(listing);

    public void RemoveListing(int listingID) => listings.RemoveAll(l => l.ID == listingID);

    public void UpdateListing(IRealEstateListing listing)
    {
        var existing = listings.FirstOrDefault(l => l.ID == listing.ID);
        if (existing != null)
        {
            existing.Title = listing.Title;
            existing.Description = listing.Description;
            existing.Price = listing.Price;
            existing.Location = listing.Location;
        }
    }

    public List<IRealEstateListing> GetListings() => listings;

    public List<IRealEstateListing> GetListingsByLocation(string location) =>
        listings.Where(l => l.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<IRealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice) =>
        listings.Where(l => l.Price >= minPrice && l.Price <= maxPrice).ToList();
}

class Program
{
    static void Main(string[] args)
    {
        RealEstateApp app = new RealEstateApp();

        
        app.AddListing(new RealEstateListing
        {
            ID = 1,
            Title = "2BHK Apartment",
            Description = "Spacious apartment with balcony",
            Price = 5000000,
            Location = "Delhi"
        });

        app.AddListing(new RealEstateListing
        {
            ID = 2,
            Title = "Luxury Villa",
            Description = "Villa with swimming pool",
            Price = 20000000,
            Location = "Mumbai"
        });

        app.AddListing(new RealEstateListing
        {
            ID = 3,
            Title = "3BHK Flat",
            Description = "Modern flat near metro",
            Price = 8000000,
            Location = "Delhi"
        });

        Console.WriteLine("All Listings:");
        foreach (var listing in app.GetListings())
        {
            Console.WriteLine($"{listing.ID} - {listing.Title} | {listing.Location} | ₹{listing.Price}");
        }

        Console.WriteLine("\nListings in Delhi:");
        var delhiListings = app.GetListingsByLocation("Delhi");
        foreach (var listing in delhiListings)
        {
            Console.WriteLine($"{listing.ID} - {listing.Title} | ₹{listing.Price}");
        }

        Console.WriteLine("\nListings between 4,000,000 and 9,000,000:");
        var priceListings = app.GetListingsByPriceRange(4000000, 9000000);
        foreach (var listing in priceListings)
        {
            Console.WriteLine($"{listing.ID} - {listing.Title} | {listing.Location} | ₹{listing.Price}");
        }

        app.UpdateListing(new RealEstateListing
        {
            ID = 1,
            Title = "2BHK Apartment (Updated)",
            Description = "Renovated apartment with balcony",
            Price = 5500000,
            Location = "Delhi"
        });

        app.RemoveListing(2);

        Console.WriteLine("\nListings After Update & Removal:");
        foreach (var listing in app.GetListings())
        {
            Console.WriteLine($"{listing.ID} - {listing.Title} | {listing.Location} | ₹{listing.Price}");
        }
    }
}