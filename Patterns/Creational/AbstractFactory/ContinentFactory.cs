using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.AbstractFactory
{

    /*	Creates an instance of several families of classes */

    abstract class Herbivore
    {

    }

    abstract class Carnivore
    {
        public abstract void Eat(Herbivore herbivore);
    }

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    class Wildebeast: Herbivore
    {

    }

    class Lion: Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine(String.Format("{0} eats {1}", this.GetType().Name, herbivore.GetType().Name));
        }
    }

    class Bison: Herbivore
    {

    }

    class Wolf: Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine(String.Format("{0} eats {1}", this.GetType().Name, herbivore.GetType().Name));
        }
    }

    class AmericaFactory: ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

    
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    class AfricaFactory: ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeast();
        }


        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            this._carnivore.Eat(this._herbivore);
        }
    }


}
