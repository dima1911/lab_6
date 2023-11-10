using System;
using System.Collections.Generic;

// Абстрактний клас Vehicle
public abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

// Клас Human
public class Human
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving.");
    }
}

// Спадкоємці класу Vehicle
public class Car : Vehicle
{
    public string Type { get; set; }

    public override void Move()
    {
        Console.WriteLine("Car is moving.");
    }
}

public class Bus : Vehicle
{
    public int PassengerCapacity { get; set; }

    public override void Move()
    {
        Console.WriteLine("Bus is moving.");
    }
}

public class Train : Vehicle
{
    public string Route { get; set; }

    public override void Move()
    {
        Console.WriteLine("Train is moving.");
    }
}

// Клас Route
public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}

// Клас TransportNetwork
public class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void MoveAllVehicles()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public void CalculateOptimalRoute(Vehicle vehicle, Route route)
    {
        // Логіка для розрахунку оптимального маршруту
        Console.WriteLine($"Optimal route calculated for {vehicle.GetType().Name} from {route.StartPoint} to {route.EndPoint}.");
    }

    public void BoardPassengers(Vehicle vehicle, int numberOfPassengers)
    {
        // Логіка для посадки пасажирів
        Console.WriteLine($"{numberOfPassengers} passengers boarded the {vehicle.GetType().Name}.");
    }

    public void DisembarkPassengers(Vehicle vehicle, int numberOfPassengers)
    {
        // Логіка для висадки пасажирів
        Console.WriteLine($"{numberOfPassengers} passengers disembarked from the {vehicle.GetType().Name}.");
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання
        TransportNetwork transportNetwork = new TransportNetwork();

        Car car = new Car { Speed = 60, Capacity = 4, Type = "Sedan" };
        Bus bus = new Bus { Speed = 40, Capacity = 30, PassengerCapacity = 20 };
        Train train = new Train { Speed = 80, Capacity = 200, Route = "A-B" };

        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        transportNetwork.MoveAllVehicles();

        Route route = new Route { StartPoint = "City A", EndPoint = "City B" };
        transportNetwork.CalculateOptimalRoute(train, route);

        transportNetwork.BoardPassengers(bus, 10);
        transportNetwork.DisembarkPassengers(bus, 5);
    }
}
