using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(); // create a new instance of the Recipe class
            int choice;

            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.EnterDetails();
                        break;
                    case 2:
                        recipe.Display();
                        break;
                    case 3:
                        recipe.Scale();
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        recipe.Clear();
                        break;
                    case 6:
                        Console.WriteLine("Exiting.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (choice != 6);
        }
    }

    class Recipe
    {
        // ingredients and steps arrays
        private string[] ingredients;
        private decimal[] quantities;
        private string[] units;
        private string[] steps;

        // automatic properties for number of ingredients and steps
        public int NumIngredients { get; private set; }
        public int NumSteps { get; private set; }

        // constructor
        public Recipe()
        {
            // initialize arrays with initial capacity of 10
            ingredients = new string[10];
            quantities = new decimal[10];
            units = new string[10];
            steps = new string[10];
        }

        // enter recipe details
        public void EnterDetails()
        {
            Console.Write("Enter number of ingredients: ");
            NumIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < NumIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                ingredients[i] = Console.ReadLine();
                Console.Write($"Enter quantity of {ingredients[i]}: ");
                quantities[i] = decimal.Parse(Console.ReadLine());
                Console.Write($"Enter unit of measurement for {ingredients[i]}: ");
                units[i] = Console.ReadLine();
            }

            Console.Write("Enter number of steps: ");
            NumSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < NumSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered.");
        }

        // display recipe
        public void Display()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine();

            // display ingredients
            for (int i = 0; i < NumIngredients; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} {ingredients[i]}");
            }

            Console.WriteLine();

            // display steps
            Console.WriteLine("Steps:");
            for (int i = 0; i < NumSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // scale recipe
        public void Scale()
        {
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
            decimal factor = decimal.Parse(Console.ReadLine());

            for (int i = 0; i < NumIngredients; i++)
            {
                quantities[i] *= factor;
            }

            Console.WriteLine("Recipe scaled.");
        }

        // reset quantities to original values
        public void ResetQuantities()
        {
            Console.WriteLine("Quantities reset to original values.");
        }

        // clear all data
        public void Clear()
        {
            NumIngredients = 0;
            NumSteps = 0;

            for (int i = 0; i < 10; i++)
            {
                ingredients[i] = null;
                quantities[i] = 0;
                units[i] = null;
                steps[i] = null;
            }

            Console.WriteLine("All data cleared.");
        }
    }
}
