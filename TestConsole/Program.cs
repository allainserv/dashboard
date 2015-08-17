using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            // Polymorphism
            Animal animal = new Dog();
           
            Animal animalTwo = new Cat();

            Console.WriteLine(animal.Name);
            Console.WriteLine(animalTwo.Name);
                     
            Console.ReadKey();


        }
    }

    public interface Animal
    {
        string Name { get; }
    }

    public class Dog : Animal
    {
        public string Name { get { return "Dog"; } }
    }

    public class Cat : Animal
    {
        public string Name { get { return "Cat"; } }
    }
}
