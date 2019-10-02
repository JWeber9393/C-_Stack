using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    interface IConsumable
    {
        string Name {get;set;}
        int Calories {get;set;}
        bool IsSpicy {get;set;}
        bool IsSweet {get;set;}
        string GetInfo();
    }   


    class Food : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo()
        {
            return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Food(string name, int cal, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    class Drink : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo()
        {
            return $"{Name} (Drink).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Drink(string name, int cal, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }
    class Buffet
    {
        public List<IConsumable> Menu;
         
        //constructor
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Curry", 500, false, false),
                new Food("Spicy Curry", 500, true, false),
                new Food("Sushi", 800, false, false),
                new Food("Mochi", 250, false, true),
                new Food("Rice", 1000, false, false),
                new Food("Noodles", 1000, false, false),
                new Food("Ramen", 1200, false, false),
                new Drink("Horchata", 350, false, true),
            };
        }
         
        public IConsumable Serve()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, Menu.Count);
            
            IConsumable meal = Menu[randomIndex];
            return meal;
        }
    }

    abstract class Ninja
    {
        protected int calorieIntake;

        public List<IConsumable> ConsumptionHistory;
         
        // add a constructor
        public Ninja()
        {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
        // add a public "getter" property called "IsFull"
        public abstract bool isFull {get;}
        // build out the Consume method
        public abstract void Consume(IConsumable item);
    }
    class SweetTooth : Ninja
    {
        
        // add a public "getter" property called "IsFull"

        public override bool isFull
        {
            get
            {
                if (calorieIntake > 1500)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        // build out the Consume method
        public override void Consume(IConsumable item)
        {
            if (isFull)
            {
                Console.WriteLine("Ninja is full and cannot Consume anymore!");
            }
            else
            {
                ConsumptionHistory.Add(item);
                if(item.IsSweet == true)
                {
                    calorieIntake += (item.Calories + 10);
                }
                else
                {
                    calorieIntake += item.Calories;
                }
                Console.WriteLine(this.calorieIntake);
                Console.WriteLine(item.GetInfo());
            }
        }
    }
    class SpiceHound : Ninja
    {
        
        // add a public "getter" property called "IsFull"
        public override bool isFull
        {
            get
            {
                if (calorieIntake > 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        // build out the Consume method
        public override void Consume(IConsumable item)
        {
            if (isFull)
            {
                Console.WriteLine("Ninja is full and cannot Consume anymore!");
            }
            else
            {
                ConsumptionHistory.Add(item);
                if(item.IsSweet == true)
                {
                    calorieIntake += (item.Calories - 5);
                }
                else
                {
                    calorieIntake += item.Calories;
                }
                Console.WriteLine(this.calorieIntake);
                Console.WriteLine(item.GetInfo());
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Buffet Menu = new Buffet();
            SweetTooth Joey = new SweetTooth();
            Joey.Consume(Menu.Serve());
            Joey.Consume(Menu.Serve());
            Joey.Consume(Menu.Serve());
            Joey.Consume(Menu.Serve());
            // Joey.Consume(Menu.Serve());
            // foreach(var i in Joey.ConsumptionHistory)
            // {
            //     Console.Write($"{i.Name}, ");
            // }
        }
    }
}