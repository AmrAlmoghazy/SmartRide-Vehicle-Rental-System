# SmartRide Vehicle Rental System

A practical C# console application demonstrating Object-Oriented Programming (OOP) principles through a vehicle rental and billing workflow.

---

## Overview

**SmartRide** is an interactive vehicle rental management console application built with C# and .NET 8. It allows users to register rental transactions for different vehicle categories, configure rental terms and category-specific add-ons, calculate total rental fees according to specific business formulas, and generate an itemized rental summary.

---

## Key Features

- **Interactive Console Interface:** Step-by-step CLI prompts guide the user through customer registration, vehicle selection, and option configuration.
- **Support for Multiple Vehicle Types:**
  - **Car:** Supports optional daily insurance coverage.
  - **Truck:** Includes cargo weight surcharges.
  - **Motorcycle:** Supports optional daily helmet rental fees.
- **Categorized Fuel Types:** Selection among Petrol, Diesel, and Electric options.
- **Automated Fee Calculation:** Computes total rental charges based on daily rates, duration, and vehicle-specific options.
- **Rental Summary Generation:** Outputs a clear, formatted breakdown of vehicle details, rates, add-ons, and total cost in Egyptian Pounds (EGP).

---

## Object-Oriented Design (OOP) Principles

The application is structured to illustrate core OOP fundamentals:

- **Abstraction & Interface Segregation (`IRentable`)**
  - Defines the core contractual behaviors: `CalculateRentalFee()` and `ShowRentalSummary()`.
- **Abstract Base Class (`Vehicle`)**
  - Implements `IRentable` and encapsulates shared state (`PlateNumber`, `RentalDays`, `DailyRate`, `FuelType`, `CustomerName`, `NationalID`).
  - Defines an `abstract double CalculateRentalFee()` method enforcing customized calculation logic in derived classes.
  - Provides a `virtual void ShowRentalSummary()` method for base property printing.
- **Inheritance & Specialization**
  - `Car`: Inherits from `Vehicle` and adds `HasInsurance` and `InsuranceFee` properties.
  - `Truck`: Inherits from `Vehicle` and adds the `WeightCharge` property.
  - `Motorcycle`: Inherits from `Vehicle` and introduces `HasHelmet` and `HelmetFee` properties. Marked as `sealed` to prevent further inheritance.
- **Polymorphism & Method Overriding**
  - Each vehicle subclass overrides `CalculateRentalFee()` with its specific pricing formula.
  - Subclasses override `ShowRentalSummary()`, calling `base.ShowRentalSummary()` and augmenting it with specialized add-on details.
- **Enumerations for Type Safety**
  - `FuelType` (`Petrol`, `Diesel`, `Electric`)
  - `VehicleType` (`Car`, `Truck`, `Motorcycle`)

---

## Pricing Calculations

All monetary values are calculated in Egyptian Pounds (EGP):

| Vehicle Type | Calculation Formula |
| :--- | :--- |
| **Car** | `(RentalDays × DailyRate) + (HasInsurance ? InsuranceFee × RentalDays : 0)` |
| **Truck** | `(RentalDays × DailyRate) + WeightCharge` |
| **Motorcycle** | `(RentalDays × DailyRate) + (HasHelmet ? HelmetFee × RentalDays : 0)` |

---

## Project Structure

```
SmartRide-Vehicle-Rental-System/
├── .gitignore               # Standard .NET gitignore file
├── Program.cs               # Application entry point (Program.Main) and CLI wizard
├── README.md                # Project documentation
├── SmartRide.csproj         # .NET 8.0 Console project configuration (SmartRide)
└── VehicleRentalSystem.cs   # Domain classes, interface, and vehicle models
```

---

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher installed on your machine.

### Build and Run

1. Open your terminal and navigate to the project directory:
   ```bash
   cd SmartRide-Vehicle-Rental-System
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

---

## Example Usage

```text
*- Welcome to SmartRide Vehicle Rental System -*

Please enter your name: John Doe
Enter your National ID: 12345678901234

Choose a Vehicle Type to Rent:
1. Car
2. Truck
3. Motorcycle

Enter your choice: 2


--- Truck Rental Details ---

Enter Plate Number: TRK-9876
Enter number of rental days: 3
Enter daily rental rate (EGP): 500

Enter fuel type:
1. Petrol
2. Diesel
3. Electric
Enter your choice: 2

Enter weight charge (EGP): 200


Rental Succussfully recorded!


Rental Summary for John Doe
--------------------------------
Vehicle Type: Truck
Plate Number: TRK-9876
Fuel Type: Diesel
Rental Days: 3
Daily Rate: 500 EGP
Weight Charge: 200 EGP

Total Rental Fee: 1700 EGP


Thank you for choosing SmartRide!
```

