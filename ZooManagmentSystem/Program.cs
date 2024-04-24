using System;
using System.Collections.Generic;

// Base class of generic animal.
public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor name and age.
    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Method for the animal to eat.
    public virtual void Eat()
    {
        Console.WriteLine($"{Name} is eating generic food.");
    }

    // Method for the animal to sleep.
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
    }

    // Abstract method for the animal to speak.
    public abstract void Speak();
}


public interface IFeedable
{
    string Feed(string food);
}

public interface IMovable
{
    void Move();
}

// Lion class, inherits from Animal and implements IFeedable and IMovable.
public class Lion : Animal, IFeedable, IMovable
{
    public Lion(string name, int age) : base(name, age) { }

    public override void Eat()
    {
        Console.WriteLine($"{Name} eats meat.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} roars.");
    }

    public string Feed(string food)
    {
        if (food.ToLower() == "meat")
        {
            return $"{Name} is fed {food} and is happy.";
        }
        return $"{Name} does not eat {food}. {Name} only eats meat.";
    }

    public void Move()
    {
        Console.WriteLine($"{Name} runs swiftly.");
    }
}

// Bear class, inherits from Animal.
public class Bear : Animal
{
    public Bear(string name, int age) : base(name, age) { }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says 'Hello!'");
    }
}

// Penguin class, inherits from Animal and implements IMovable.
public class Penguin : Animal, IMovable
{
    public Penguin(string name, int age) : base(name, age) { }

    public override void Speak()
    {
        Console.WriteLine($"{Name} does a quiet hiss.");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} moves slowly.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // list of animals in the zoo.
        List<Animal> zoo = new List<Animal>
        {
            new Lion("Mphoz", 5),
            new Bear("Katliey", 3),
            new Penguin("Kat", 50)
        };

        // Display the animals added to the zoo.
        DisplayAnimalsAdded(zoo);

        while (true)
        {
            Console.WriteLine("\nZoo Management System");
            Console.WriteLine("1. List Animals");
            Console.WriteLine("2. Feed Animals");
            Console.WriteLine("3. Make Animals Speak");
            Console.WriteLine("4. Move Animals");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1": 
                    foreach (var animal in zoo)
                    {
                        Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");
                    }
                    break;
                case "2":
                    foreach (var animal in zoo)
                    {
                        if (animal is IFeedable feedable)
                        {
                            Console.WriteLine(feedable.Feed("meat")); 
                        }
                    }
                    break;
                case "3": 
                    foreach (var animal in zoo)
                    {
                        animal.Speak();
                    }
                    break;
                case "4": 
                    foreach (var animal in zoo)
                    {
                        if (animal is IMovable movable)
                        {
                            movable.Move();
                        }
                    }
                    break;
                case "5": 
                    return;
                default: // Handle invalid options.
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Display the animals added to the zoo.
    static void DisplayAnimalsAdded(List<Animal> zoo)
    {
        Console.WriteLine("Welcome to the Zoo Management System!");
        Console.WriteLine("The following animals have been added to the zoo:");
        foreach (var animal in zoo)
        {
            Console.WriteLine($" - {animal.Name} the {animal.GetType().Name} (Age: {animal.Age})");
        }
        Console.WriteLine();
    }
}
