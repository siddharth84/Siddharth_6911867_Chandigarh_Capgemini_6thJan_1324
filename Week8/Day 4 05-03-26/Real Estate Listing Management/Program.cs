using System;
using System.Collections.Generic;
using System.Linq;

public class RealEstateListing
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Location { get; set; }
}

public class RealEstateApp
{
    private List<RealEstateListing> listings = new List<RealEstateListing>();

    public void AddListing(RealEstateListing listing)
    {
        listings.Add(listing);
    }

    public bool RemoveListing(int listingID)
    {
        var listing = listings.FirstOrDefault(x => x.ID == listingID);

        if (listing != null)
        {
            listings.Remove(listing);
            return true;
        }

        return false;
    }

    public bool UpdateListing(RealEstateListing updatedListing)
    {
        var listing = listings.FirstOrDefault(x => x.ID == updatedListing.ID);

        if (listing != null)
        {
            listing.Title = updatedListing.Title;
            listing.Description = updatedListing.Description;
            listing.Price = updatedListing.Price;
            listing.Location = updatedListing.Location;

            return true;
        }

        return false;
    }

    public List<RealEstateListing> GetListingsByLocation(string location)
    {
        return listings
            .Where(x => x.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

public class Program
{
    public static void Main()
    {
        RealEstateApp app = new RealEstateApp();

        app.AddListing(new RealEstateListing
        {
            ID = 1,
            Title = "Luxury Apartment",
            Description = "2BHK with sea view",
            Price = 500000,
            Location = "Mumbai"
        });

        app.AddListing(new RealEstateListing
        {
            ID = 2,
            Title = "Villa",
            Description = "Independent house",
            Price = 1200000,
            Location = "Delhi"
        });

        var listings = app.GetListingsByLocation("Mumbai");

        foreach (var l in listings)
        {
            Console.WriteLine($"{l.ID} {l.Title} {l.Price} {l.Location}");
        }
    }
}