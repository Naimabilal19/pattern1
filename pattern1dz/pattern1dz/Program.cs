using System;

namespace FactoryMethod
{
    abstract class Creator
    {
        public abstract ITransport FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Creator: Okay \n\n"
                + product.Operation() +"\n"+  product.fuelconsumption() + "\n" + product.costdelivery() + "\n" + product.distance();

            return result;
        }
    }

    class Truck : Creator
    {
        public override ITransport FactoryMethod()
        {
            return new Truck1();
        }
    }

    class Ship : Creator
    {
        public override ITransport FactoryMethod()
        {
            return new Ship1();
        }
    }

    class Plane : Creator
    {
        public override ITransport FactoryMethod()
        {
            return new Plane1();
        }
    }


    public interface ITransport
    {
        string Operation();
        string fuelconsumption();
        string costdelivery();
        string distance();
    }

    class Truck1 : ITransport
    {
        public string Operation()
        {
            return "Result of Truck";
        }
        public string fuelconsumption()
        {
            return "14 liters per 100 kilometers";
        }
        public string costdelivery()
        {
            int c = 40;
            string cost = $"delivery cost per 1 kilometer: {c}";
            return cost;
        }
        public string distance()
        {
            return "370 kilometers";
        }
    }

    class Ship1 : ITransport
    {
        public string Operation()
        {
            return "Result of Ship";
        }
        public string fuelconsumption()
        {
            return "35 liters per hour";
        }
        public string costdelivery()
        {
            int c = 1;
            string cost = $"1.00 dollar/kg: {c}";
            return cost;
        }
        
        public string distance()
        {
            return "900 kilometers";
        }
    }

    class Plane1 : ITransport
    {
        public string Operation()
        {
            return "Result of Plane";
        }
        public string fuelconsumption()
        {
            return "4.73 liters per passenger per 100 km";
        }
        public string costdelivery()
        {
            int c = 1;
            string cost = $"Kyiv(Borispil) – Washington(USA)$: {c}";
            return cost;
        }
        
        public string distance()
        {
            return "1000 kilometers";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the Truck.");
            ClientCode(new Truck());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the Ship.");
            ClientCode(new Ship());

            Console.WriteLine();

            Console.WriteLine("App: Launched with the Plane.");
            ClientCode(new Plane());
        }
        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: I want to know the data on transportation by different modes of transport\n" + creator.SomeOperation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}