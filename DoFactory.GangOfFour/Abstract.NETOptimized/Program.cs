using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstract.NETOptimized
{
    class Program
    {
        static void Main(string[] args)
        {
            var africa = new AnimalWorld<Africa>();
            africa.RunFoodChain();

            var america = new AnimalWorld<America>();
            america.RunFoodChain();

            // Wait for user input
            Console.ReadKey();
        }
  
    }

    interface ICarnivore
    {
        void Eat(IHerbivore h);
    }

    interface IHerbivore
    {

    }

    interface IAnimalWorld
    {
        void RunFoodChain();
    }

    interface IContinentFactory
    {
        IHerbivore CreateHerbivore();
        ICarnivore CreateCarnivore();
    }

    class America : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Bison();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    class Africa : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Wilderbeast();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    class Bison : IHerbivore
    {
    }

    class Wilderbeast : IHerbivore
    {

    }

    class Lion : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class Wolf : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class AnimalWorld<T> : IAnimalWorld where T : IContinentFactory, new()
    {
        private IHerbivore _herbivore;
        private ICarnivore _carnivore;
        private T _factory;

        public AnimalWorld()
        {
            _factory = new T();

            _carnivore = _factory.CreateCarnivore();
            _herbivore = _factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
