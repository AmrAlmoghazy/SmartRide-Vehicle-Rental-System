namespace Lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n*- Welcome to SmartRide Vehicle Rental System -*\n");
            Console.Write("Please enter your name: ");
            string Cname = Console.ReadLine();
            Console.Write("Enter your National ID: ");
            string Cid = Console.ReadLine();

            Console.WriteLine("\nChoose a Vehicle Type to Rent:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");
            Console.WriteLine("3. Motorcycle");
            
            int vehicleType = ReadChoice("\nEnter your choice: ", 1, 3);

            Console.WriteLine($"\n\n--- {(VehicleType)vehicleType} Rental Details ---\n");

            Console.Write("Enter Plate Number: ");
            string plateNumber = Console.ReadLine();

            Console.Write("Enter number of rental days: ");
            int rentalDays = (int)ReadPositiveNum("Invalid! Please enter a positive number: ");

            Console.Write("Enter daily rental rate (EGP): ");
            double dailyRate = ReadPositiveNum("Invalid! Please enter a valid rate: ");

            Console.WriteLine("\nEnter fuel type:");
            Console.WriteLine("1. Petrol");
            Console.WriteLine("2. Diesel");
            Console.WriteLine("3. Electric");

            int fueltype = ReadChoice("Enter your choice: ", 1, 3);
            Console.WriteLine();


            VehicleRentalSystem.Vehicle vehicle = null;

            switch (vehicleType)
            {
                case 1:
                    char insurance = '?';
                    while (insurance != 'y' && insurance != 'n')
                    {
                        Console.Write("Do you want to add insurance? (y/n): ");
                        insurance = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                    }
                    bool hasInsurance = insurance == 'y';

                    double insuranceFee = 0;
                    if (hasInsurance)
                    {
                        Console.Write("\nInsurance fee per day: ");
                        insuranceFee = ReadPositiveNum("Invalid! Please enter a valid fee: ");
                    }

                    vehicle = new VehicleRentalSystem.Car(plateNumber, rentalDays, dailyRate, (VehicleRentalSystem.FuelType)fueltype, Cname, Cid, hasInsurance, insuranceFee);
                    break;

                case 2:
                    double weightCharge;
                    Console.Write("Enter weight charge (EGP): ");
                    weightCharge = ReadPositiveNum("Invalid! Please enter a valid charge: ");
                    
                    vehicle = new VehicleRentalSystem.Truck(plateNumber, rentalDays, dailyRate, (VehicleRentalSystem.FuelType)fueltype, Cname, Cid, weightCharge);
                    break;

                case 3:
                    char helmet = '?';
                    while (helmet != 'y' && helmet != 'n')
                    {
                        Console.Write("Do you want to rent a helmet? (y/n): ");
                        helmet = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                    }
                    bool hasHelmet = helmet == 'y';

                    double helmetFee = 0;
                    if (hasHelmet)
                    {
                        Console.Write("\nHelmet rental fee per day: ");
                        helmetFee = ReadPositiveNum("Invalid! Please enter a valid fee: ");
                    }

                    vehicle = new VehicleRentalSystem.Motorcycle(plateNumber, rentalDays, dailyRate, (VehicleRentalSystem.FuelType)fueltype, Cname, Cid, hasHelmet, helmetFee);
                    break;
            }
            
            Console.WriteLine("\n\nRental Succussfully recorded!\n\n");

            vehicle.ShowRentalSummary();

            Console.WriteLine("\n\nThank you for choosing SmartRide!\n");
        }

        public enum VehicleType : byte
        {
            Car = 1,
            Truck = 2,
            Motorcycle = 3
        }

        static int ReadChoice(string message, int from, int to)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= from && choice <= to)
                    return choice;
                else
                    Console.WriteLine("Invalid choice.");
            }
        }

        static double ReadPositiveNum(string errorMessage)
        {
            double num;
            while (!double.TryParse(Console.ReadLine(), out num) || num <= 0)
            {
                    Console.Write(errorMessage);
            }

            return num;
        }
    }
}
