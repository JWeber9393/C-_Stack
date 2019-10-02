using System;

namespace WizNinSam
{
    class Program
    {
//=========== HUMAN CLASS ===============//
        class Human
        {
            // Fields for Human
            public string Name;
            public int Strength;
            public int Intelligence;
            public int Dexterity;
            protected int health;
             
            // add a public "getter" property to access health
            public int healthProp
            {
                get { return health; }
                set { health = value; }
            }
             
            // Add a constructor that takes a value to set Name, and set the remaining fields to default values
            public Human(string name)
            {
                Name = name;
                Strength = 3;
                Intelligence = 3;
                Dexterity = 3;
                health = 100;
            }
             
            // Add a constructor to assign custom values to all fields
            public Human(string name, int str, int intel, int dex, int hp)
            {
                Name = name;
                Strength = str;
                Intelligence = intel;
                Dexterity = dex;
                health = hp;
            }
             
             
            // Build Attack method
            public virtual int Attack(Human target)
            {
                int dmg = Strength * 3;
                target.health -= dmg;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
                return target.health;
            }
        }
//=========== END HUMAN CLASS ===============//

        class Wizard : Human
        {
            
            //Default Wizard
            public Wizard(string name) :  base(name) 
            {
                Intelligence = 25;
                health = 50;
            }


            public override int Attack(Human target)
            {
                int dmg = Intelligence * 5;
                target.healthProp -= dmg;
                this.health += dmg;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
                return target.healthProp;
            }

            public int Heal(Human target)
            {
                int heal = Intelligence * 10;
                target.healthProp += heal;
                return target.healthProp;
            }
        
        }
        class Ninja : Human
        {
            //Default Ninja
            public Ninja(string name) : base(name)
            {
                Dexterity = 175;
            }
            

            public override int Attack(Human target)
            {
                Random rand = new Random();
                int chance = rand.Next(0,6);
                int dmg = Dexterity * 5;
                int crit = (dmg+(dmg/5));
                if(chance == 5)
                {
                    target.healthProp -= crit;
                    Console.WriteLine($"{Name} attacked {target.Name} for {crit} damage!");
                }
                else
                {
                    target.healthProp -= dmg;
                    Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
                }
                return target.healthProp;
            }

            public int Steal(Human target)
            {
                target.healthProp -= 5;
                this.health += 5;
                Console.WriteLine($"{this.Name} stole 5 HP from {target.Name}");
                return target.healthProp;
            }
        }
        class Samurai : Human
        {
            //Default Samurai
            public Samurai(string name) : base(name)
            {
                health = 200;
            }
            

            public override int Attack(Human target)
            {
                int dmg = Strength * 3;
                if(this.health == 50)
                {
                    target.healthProp = 0;
                }
                else
                {
                    target.healthProp -= dmg;
                }
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
                return target.healthProp;
            }

            public void Meditate(Human Samurai)
            {
                this.health = 200;
                Console.WriteLine($"{this.Name} fully healed after meditating!");
            }

        }
        static void Main(string[] args)
        {
            Wizard Wiz = new Wizard("Wiz");
            Ninja Naruto = new Ninja("Naruto");
            Samurai Kenshi = new Samurai("Kenshi");

            Naruto.Steal(Wiz);
            Naruto.Attack(Kenshi);
            Wiz.Attack(Naruto);
            Wiz.Heal(Wiz);
            Kenshi.Attack(Naruto);
            Kenshi.Meditate(Kenshi);
            Console.WriteLine($"Wiz's HP: {Wiz.healthProp}");
            Console.WriteLine($"Naruto's HP: {Naruto.healthProp}");
            Console.WriteLine($"Kenshi's HP: {Kenshi.healthProp}");
        }
    }
}
