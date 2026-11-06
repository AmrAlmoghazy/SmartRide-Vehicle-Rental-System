using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    internal class VehicleRentalSystem
    {
        public enum FuelType
        {
            Petrol,
            Diesel,
            Electric
        }

        public interface IRentable
        {
            double CalculateRentalFee();
            void ShowRentalSummary();
        }

        public abstract class Vehicle : IRentable
        {
            public string PlateNumber { get; set; }
            public int RentalDays { get; set; }
            public double DailyRate { get; set; }
            public FuelType FuelType { get; set; }
            public string CustomerName { get; set; }
            public string NationalID { get; set; }

            public Vehicle(string plateNumber, int rentalDays, double dailyRate, FuelType fuelType, string customerName, string nationalID)
            {
                PlateNumber = plateNumber;
                RentalDays = rentalDays;
                DailyRate = dailyRate;
                FuelType = fuelType;
                CustomerName = customerName;
                NationalID = nationalID;
            }

            public abstract double CalculateRentalFee();

            public virtual void ShowRentalSummary()
            {
                Console.WriteLine($"Plate Number: {PlateNumber}");
                Console.WriteLine($"Fuel Type: {FuelType}");
                Console.WriteLine($"Rental Days: {RentalDays}");
                Console.WriteLine($"Daily Rate: {DailyRate} EGP");
            }
        }

        public class Car : Vehicle
        {
            public bool HasInsurance { get; set; }
            public double InsuranceFee { get; set; }

            public Car(string plateNumber, int rentalDays, double dailyRate, FuelType fuelType, string customerName, string nationalID, bool hasInsurance, double insuranceFee)
                : base(plateNumber, rentalDays, dailyRate, fuelType, customerName, nationalID)
            {
                HasInsurance = hasInsurance;
                InsuranceFee = insuranceFee;
            }

            public override double CalculateRentalFee()
            {
                double total = RentalDays * DailyRate;
                if (HasInsurance)
                    total += InsuranceFee * RentalDays;
                
                return total;
            }

            public override void ShowRentalSummary()
            {
                Console.WriteLine($"Rental Summary for {CustomerName}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Vehicle Type: Car");
                base.ShowRentalSummary();

                if (HasInsurance)
                {
                    Console.WriteLine($"Insurance Included: Yes ({InsuranceFee}/day)");
                }
                else
                {
                    Console.WriteLine("Insurance Included: No");
                }

                Console.WriteLine($"\nTotal Rental Fee: {CalculateRentalFee()} EGP");
            }

        }

        public class Truck : Vehicle
        {
            public double WeightCharge { get; set; }

            public Truck(string plateNumber, int rentalDays, double dailyRate, FuelType fuelType, string customerName, string nationalID, double weightCharge)
                : base(plateNumber, rentalDays, dailyRate, fuelType, customerName, nationalID)
            {
                WeightCharge = weightCharge;
            }

            public override double CalculateRentalFee()
            {
                return (RentalDays * DailyRate) + WeightCharge;
            }

            public override void ShowRentalSummary()
            {
                Console.WriteLine($"Rental Summary for {CustomerName}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Vehicle Type: Truck");
                base.ShowRentalSummary();
                Console.WriteLine($"Weight Charge: {WeightCharge} EGP");

                Console.WriteLine($"\nTotal Rental Fee: {CalculateRentalFee()} EGP");
            }
        }

        public sealed class Motorcycle : Vehicle
        {
            public bool HasHelmet { get; set; }
            public double HelmetFee { get; set; }

            public Motorcycle(string plateNumber, int rentalDays, double dailyRate, FuelType fuelType, string customerName, string nationalID, bool hasHelmet, double helmetFee)
                : base(plateNumber, rentalDays, dailyRate, fuelType, customerName, nationalID)
            {
                HasHelmet = hasHelmet;
                HelmetFee = helmetFee;
            }

            public override double CalculateRentalFee()
            {
                double total = RentalDays * DailyRate;
                if (HasHelmet)
                    total += HelmetFee * RentalDays;

                return total;
            }

            public override void ShowRentalSummary()
            {
                Console.WriteLine($"Rental Summary for {CustomerName}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Vehicle Type: Motorcycle");
                base.ShowRentalSummary();

                if (HasHelmet)
                {
                    Console.WriteLine($"Helmet Rented: Yes ({HelmetFee}/day)");
                }
                else
                {
                    Console.WriteLine("Helmet Rented: No");
                }

                Console.WriteLine($"\nTotal Rental Fee: {CalculateRentalFee()} EGP");
            }
        }
    }
}
