using System;
using System.Collections.Generic;

namespace GameSystem
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Level { get; protected set; } = 1;
        public int Health { get; protected set; }
        public int Mana { get; protected set; }
        public int Experience { get; private set; } = 0;

        public Character(string name, int health, int mana)
        {
            Name = name;
            Health = health;
            Mana = mana;
        }

        public abstract void Attack(Character target);

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage! Remaining Health: {Math.Max(0, Health)}");
            if (Health <= 0) Console.WriteLine($"{Name} has been defeated!");
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} XP!");
            if (Experience >= 100) LevelUp();
        }

        protected virtual void LevelUp()
        {
            Level++;
            Experience = 0;
            Health += 20;
            Console.WriteLine($"LEVEL UP! {Name} is now Level {Level}. Health increased.");
        }
    }

    public class Warrior : Character
    {
        public int Defense { get; set; } = 10;

        public Warrior(string name) : base(name, 150, 20) { }

        public override void Attack(Character target)
        {
            int damage = 15 + (Level * 2);
            Console.WriteLine($"{Name} swings a heavy Greatsword at {target.Name}!");
            target.TakeDamage(damage);
        }

        protected override void LevelUp()
        {
            base.LevelUp();
            Defense += 5;
            Console.WriteLine($"{Name}'s Defense increased to {Defense}.");
        }
    }

    public class Mage : Character
    {
        public Mage(string name) : base(name, 80, 150) { }

        public override void Attack(Character target)
        {
            if (Mana >= 20)
            {
                Mana -= 20;
                int damage = 25 + (Level * 5);
                Console.WriteLine($"{Name} casts a massive Fireball at {target.Name}!");
                target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine($"{Name} is out of mana!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Warrior conan = new Warrior("Conan");
            Mage gandalf = new Mage("Gandalf");

            Console.WriteLine("--- Battle Start ---");

            conan.Attack(gandalf);
            gandalf.Attack(conan);

            Console.WriteLine("\n--- Post-Battle Gains ---");
            conan.GainExperience(120); 

            Console.ReadKey();
        }
    }
}
