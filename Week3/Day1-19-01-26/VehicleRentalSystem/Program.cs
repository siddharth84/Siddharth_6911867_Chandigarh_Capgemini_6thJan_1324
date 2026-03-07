using System;
using System.Collections.Generic;

namespace VehicleRentalSystem
{
    public abstract class Vehicle
    {
        public string PlateNumber { get; private set; }
        public string Model { get; set; }
        public decimal DailyRate { get; protected set; }
        public bool IsAvailable { get; private set; } = true;

        public Vehicle(string plateNumber, string model, decimal dailyRate)
        {
            PlateNumber = plateNumber;
            Model = model;
            DailyRate = dailyRate;
        }

        public void MarkAsRented() => IsAvailable = false;
        public void MarkAsReturned() => IsAvailable = true;

        public virtual decimal CalculateCost(int days)
        {
            return DailyRate * days;
        }

        public abstract void DisplayDetails();
    }

    public class Car : Vehicle
    {
        public Car(string plate, string model) : base(plate, model, 50.00m) { }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Car] {Model} | Plate: {PlateNumber} | Rate: ${DailyRate}/day");
        }
    }

    public class Truck : Vehicle
    {
        public Truck(string plate, string model) : base(plate, model, 100.00m) { }

        public override decimal CalculateCost(int days)
        {
            return base.CalculateCost(days) + 25.00m; 
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Truck] {Model} | Plate: {PlateNumber} | Rate: ${DailyRate}/day (+ $25 Insurance)");
        }
    }

    public class RentalTransaction
    {
        public Vehicle RentedVehicle { get; private set; }
        public string CustomerName { get; private set; }
        public int RentalDays { get; private set; }
        public decimal TotalCost { get; private set; }

        public RentalTransaction(Vehicle vehicle, string customer, int days)
        {
            RentedVehicle = vehicle;
            CustomerName = customer;
            RentalDays = days;
            TotalCost = vehicle.CalculateCost(days);

            vehicle.MarkAsRented();
        }

        public void PrintReceipt()
        {
            Console.WriteLine("\n--- RENTAL RECEIPT ---");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Vehicle: {RentedVehicle.Model} ({RentedVehicle.PlateNumber})");
            Console.WriteLine($"Duration: {RentalDays} days");
            Console.WriteLine($"Total Paid: ${TotalCost}");
            Console.WriteLine("----------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("ABC-123", "Toyota Camry");
            Truck myTruck = new Truck("BIG-999", "Ford F-150");

            Console.WriteLine("Available Vehicles:");
            myCar.DisplayDetails();
            myTruck.DisplayDetails();

            Console.WriteLine("\nProcessing Rental for John Doe...");
            RentalTransaction transaction = new RentalTransaction(myTruck, "John Doe", 3);

            transaction.PrintReceipt();

            myTruck.MarkAsReturned();
            Console.WriteLine($"Vehicle {myTruck.PlateNumber} is now available: {myTruck.IsAvailable}");

            Console.ReadKey();
        }
    }
}
