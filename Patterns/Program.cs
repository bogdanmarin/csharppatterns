using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Creational.AbstractFactory;
using Patterns.Creational.Builder;

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

        }
    }
}
