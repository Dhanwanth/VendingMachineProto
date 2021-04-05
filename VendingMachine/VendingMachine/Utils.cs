using System;
namespace VendingMachine
{
    public class Utils
    {
        public static int CheckChoice(int choice, int numberOfChoices, Func<int> func)
        {
            if (choice < 1 || choice > numberOfChoices)
            {
                Console.Clear();
                Console.WriteLine("   ....Error Reading Input please enter a valid choice and try again...");
                choice = func();
            }

            return choice;
        }

        public static int CheckForInteger(string input, Func<int> func)
        {
            if (!Int32.TryParse(input, out var choice))
            {
                Console.Clear();
                Console.WriteLine("   ....Error Reading Input please enter valid input, try again...");
                choice = func();
            }
            else if (choice <= 0)
            {
                Console.WriteLine("... Not a valid choice");
                choice = func();
            }
            return choice;
        }
    }
}
