using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Creational.AbstractFactory;
using Patterns.Creational.Builder;
using Patterns.Creational.FactoryMethod;
using Patterns.Creational.Prototype;
using Patterns.Creational.Singleton;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            //Creational Patterns

            //Abstract Factory
            AnimalWorld americaWorld = new AnimalWorld(new AmericaFactory());
            AnimalWorld africaWorld = new AnimalWorld(new AfricaFactory());

            americaWorld.RunFoodChain();
            africaWorld.RunFoodChain();

            //Builder

            VehicleBuilder builder = null;
            Shop shop = new Shop();

            builder = new CarBuilder();

            shop.Construct(builder);

            builder.Vehicle.Show();

            Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

            // Display document pages

            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }


            ColorManager colorManager = new ColorManager();
            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors

            colorManager["angry"] = new Color(255, 54, 0);
            colorManager["peace"] = new Color(128, 211, 128);
            colorManager["flame"] = new Color(211, 34, 20);

            Color color1 = colorManager["red"].Clone() as Color;
            Color color2 = colorManager["peace"].Clone() as Color;
            Color color3 = colorManager["flame"].Clone() as Color;

            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }


            // Wait for user
            Console.ReadKey();
        }
    }
}
