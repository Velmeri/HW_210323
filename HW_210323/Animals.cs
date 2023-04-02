using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_210323
{
    abstract public class Herbivore
    {
        public int Weight { get; set; }

        public bool Life { get; set; }

        public Herbivore(int weight)
        {
            Weight = weight;
            Life = true;
        }

        public void Eat()
        {
            Weight += 10;
        }
    }

    abstract public class Carnivore
    {
        public int Power { get; set; }

        public Carnivore(int power)
        {
            Power = power;
        }

        public void Eat(ref Herbivore herbivore)
        {
            if (Power > herbivore.Weight) {
                herbivore.Life = false;
                Power += herbivore.Weight;
                herbivore.Weight = 0;
            } else {
                herbivore.Weight -= 10;
                if (herbivore.Weight < 0) {
                    herbivore.Weight = 0;
                    herbivore.Life = false;
                }
            }
        }
    }

    public class Wildebeest : Herbivore
    {
        public Wildebeest() : base(10) { }
        public Wildebeest(int weight) : base(weight) { }
    }

    public class Bison : Herbivore
    {
        public Bison() : base(10) { }
        public Bison(int weight) : base(weight) { }
    }

    class Lion : Carnivore
    {
        public Lion() : base(10) { }
        public Lion(int power) : base(power) { }
    }

    class Wolf : Carnivore
    {
        public Wolf() : base(10) { }
        public Wolf(int power) : base(power) { }
    }

    public abstract class Continent
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    public class Africa : Continent
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    public class NorthAmerica : Continent
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

    public class AnimalWorld
    {
        private Herbivore herbivore;
        private Carnivore carnivore;

        public AnimalWorld(Continent continent)
        {
            herbivore = continent.CreateHerbivore();
            carnivore = continent.CreateCarnivore();
        }

        public void HerbivoreNutrition()
        {
            Console.WriteLine("Herbivore Nutrition:");
            herbivore.Eat();
            Console.WriteLine($"Herbivore weight after eating: {herbivore.Weight}");
        }

        public void CarnivoreNutrition()
        {
            Console.WriteLine("Carnivore Nutrition:");
            carnivore.Eat(ref herbivore);
            Console.WriteLine($"Carnivore power after eating: {carnivore.Power}");
            Console.WriteLine($"Herbivore weight after being eaten: {herbivore.Weight}");
        }
    }
}
