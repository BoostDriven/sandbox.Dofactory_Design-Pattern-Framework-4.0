using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstract.RealWorld
{
    class Program
    {
        static void Main()
        {
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Console.ReadLine();
        }
    }

    abstract class ContinentFactory {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    abstract class Herbivore { 
    
    }

    abstract class Carnivore {
        public abstract void Eat(Herbivore h);
    }

    class AfricaFactory : ContinentFactory {

        public override Herbivore CreateHerbivore()
        {
            return new Wilderbeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    class AmericaFactory : ContinentFactory
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

    class Wilderbeest : Herbivore
    {

    }

    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class Bison : Herbivore
    {

    }

    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
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
            _carnivore.Eat(_herbivore);
        }
    }
}
