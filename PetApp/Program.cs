using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{

    /* Class: Pet
     * Author: Katie Bogart
     * Purpose: holds the framework for a pet object
     * Restrictions: None
     */
    public abstract class Pet
    {
        private string name;
        public int age;

        /* Method: Name
         * Purpose: 
         * Restrictions: None
         */
        public string Name
        {
            get
            { 
                return name; 
            }

            set
            {
                name = value;
            }
        }

        /* Method: Eat
         * Purpose: implementation in child classes
         * Restrictions: None
         */
        public abstract void Eat();

        /* Method: Play
         * Purpose: implementation in child classes
         * Restrictions: None
         */
        public abstract void Play();

        /* Method: GoToVet
         * Purpose: implementation in child classes
         * Restrictions: None
         */
        public abstract void GotoVet();

        /* Method: Pet
         * Purpose: create an instance of Pet
         * Restrictions: None
         */
        public Pet()
        {

        }

        /* Method: Pet
         * Purpose: create an instance of Pet with the given name and age
         * Restrictions: None
         */
        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    /* Class: Pets
     * Author: Katie Bogart
     * Purpose: hold a list of pets
     * Restrictions: None
     */
    public class Pets
    {
        public List<Pet> petList = new List<Pet>();

        /* Indexer
         * Purpose: string-based index for sorted list
         * Restrictions: None
         * CODE COPIED FROM ASSIGNMENT
         */
        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        /* Method: Count
         * Purpose: return the number of items in the pet list
         * Restrictions: None
         */
        public int Count
        {
            get {
                return petList.Count;
            }
        }

        /* Method: Add
         * Purpose: add a pet to the list
         * Restrictions: None
         */
        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        /* Method: Remove
         * Purpose: remove the first occurrence of the pet from the list
         * Restrictions: None
         */
        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }

        /* Method: Remove
         * Purpose: remove the pet at a certain index in the list
         * Restrictions: None
         */
        public void RemoveAt(int petEI)
        {
            petList.RemoveAt(petEI);
        }
    }

    /* Interface: Cat
     * Author: Katie Bogart
     * Purpose: holds the framework for a cat object
     * Restrictions: None
     */
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }

    /* Interface: Dog
     * Author: Katie Bogart
     * Purpose: holds the framework for a dog object
     * Restrictions: None
     */
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }

    /* Class: Cat
     * Author: Katie Bogart
     * Purpose: contain framework for pet object
     * Restrictions: None
     */
    public class Cat : Pet, ICat
    {

        /* Method: Eat
         * Purpose: display that the cat is eating
         * Restrictions: None
         */
        public override void Eat()
        {
            Console.WriteLine($"{this.Name} is enjoing its food!");
        }

        /* Method: Play
         * Purpose: display that the cat is playing
         * Restrictions: None
         */
        public override void Play()
        {
            Console.WriteLine($"{this.Name} loves its mouse toy!");
        }

        /* Method: Purr
         * Purpose: display that the cat is purring
         * Restrictions: None
         */
        public void Purr()
        {
            Console.WriteLine($"{this.Name}: PURRRRRRR");
        }

        /* Method: Scratch
         * Purpose: display that the cat is scratching
         * Restrictions: None
         */
        public void Scratch()
        {
            Console.WriteLine($"{this.Name} is giving its scratching post a workout!");
        }

        /* Method: GotoVet
         * Purpose: display that the cat is going to the vet
         * Restrictions: None
         */
        public override void GotoVet()
        {
            Console.WriteLine($"{this.Name} is headed to the vet!");
        }

        /* Method: Cat
         * Purpose: creates an instance of a cat object
         * Restrictions: None
         */
        public Cat()
        {
            
        }
    }

    /* Class: Dog
     * Author: Katie Bogart
     * Purpose: contain framework for pet object
     * Restrictions: None
     */
    public class Dog : Pet, IDog
    {
        public string license;

        /* Method: Eat
         * Purpose: display that the dog is eating
         * Restrictions: None
         */
        public override void Eat()
        {
            Console.WriteLine($"{this.Name} is enjoing its food!");
        }

        /* Method: Play
         * Purpose: display that the dog is playing
         * Restrictions: None
         */
        public override void Play()
        {
            Console.WriteLine($"{this.Name} loves its squeaky ball!");
        }

        /* Method: Bark
         * Purpose: display that the dog is barking
         * Restrictions: None
         */
        public void Bark()
        {
            Console.WriteLine($"{this.Name}: BARK BARK");
        }

        /* Method: NeedWalk
         * Purpose: display that the dog needs a walk
         * Restrictions: None
         */
        public void NeedWalk()
        {
            Console.WriteLine($"{this.Name} really wants to walk!");
        }

        /* Method: GotoVet
         * Purpose: display that the dog is going to the vet
         * Restrictions: None
         */
        public override void GotoVet()
        {
            Console.WriteLine($"{this.Name} is headed to the vet!");
        }

        /* Method: Dog
         * Purpose: creates an instance of a dog object with the given license, name, and age
         * Restrictions: None
         */
        public Dog(string szLicence, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicence;
        }
    }



    /* Class: Program
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    internal class Program
    {

        /* Method: Main
         * Purpose: create reference variables for pets and interfaces, list of pets, and random number generator
         *          iterate through a for loop 50 times
         *              determine whether a new item is made or one is accessed
         *          randomly call a member method
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // variables defined in Q1
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;
            // pet list in Q2
            Pets pets = new Pets();
            // random number generator in Q3
            Random rand = new Random();

            // iterate through 50 times
            for (int i = 0; i <50; i++)
            {
                bool validData = false;
                // SKELETON COPIED FROM ASSIGNMENT Q4a
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    // create a dog object with user-inputted values
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a Dog!");
                        Console.Write("Dog's Name: ");
                        string dogName = Console.ReadLine();
                        Console.Write("Dog's Age: ");
                        int dogAge = 0;
                        // make sure the age is an int
                        while (!validData)
                        {
                            try
                            {
                                dogAge = int.Parse(Console.ReadLine());
                                validData = true;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Age!");
                            }
                        }
                        Console.Write("Dog's License: ");
                        string dogLicense = Console.ReadLine();
                        dog = new Dog(dogLicense, dogName, dogAge);
                        pets.Add(dog);

                    }
                    // create a cat object with user-inputted values
                    else
                    {
                        Console.WriteLine("You bought a cat!");
                        Console.Write("Cat's Name: ");
                        string catName = Console.ReadLine();
                        Console.Write("Cat's Age: ");
                        int catAge = 0;
                        // make sure the age is an int
                        while (!validData)
                        {
                            try
                            {
                                catAge = int.Parse(Console.ReadLine());
                                validData = true;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Age!");
                            }
                        }
                        // cat only has default constructor, set values manually
                        cat = new Cat();
                        cat.Name = catName;
                        cat.age = catAge;
                        pets.Add(cat);
                    }
                    validData = false;
                }
                // 9 in 10 chance of picking an animal from the pets list
                else
                {
                    thisPet = pets[rand.Next(0, pets.Count)];
                    // make sure there is a pet action to perform actions on
                    if (thisPet != null)
                    {
                        // figure out which type of pet it is
                        if (thisPet.GetType() == typeof(Cat))
                        {
                            iCat = (Cat)thisPet;
                        }
                        else
                        {
                            iDog = (Dog)thisPet;
                        }
                        // choose an action to perform
                        int action = rand.Next(0, 5);
                        switch (action)
                        {
                            case 0:
                                thisPet.Eat();
                                break;
                            case 1:
                                thisPet.Play();
                                break;
                            case 2:
                                if (thisPet.GetType() == typeof(Cat))
                                {
                                    iCat.Purr();
                                }
                                else
                                {
                                    iDog.Bark();
                                }
                                break;
                            case 3:
                                if (thisPet.GetType() == typeof(Cat))
                                {
                                    iCat.Scratch();
                                }
                                else
                                {
                                    iDog.NeedWalk();
                                }
                                break;
                            case 4:
                                thisPet.GotoVet();
                                break;
                        }
                    }
                }

            }
        }
    }
}
