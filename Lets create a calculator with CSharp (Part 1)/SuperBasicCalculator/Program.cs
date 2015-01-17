using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperBasicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 0;
            int number2 = 0;
            int result = 0;
            int userSelectedMathOperation;
            string userInput;

            writeWelcomeMessage();

            //Reads user input and validates it is a number before converting the string to int
            Console.WriteLine("Enter a number");
            userInput = Console.ReadLine();
            validateNumber(userInput);
            number1 = Convert.ToInt32(userInput);

            //Reads user input and validates it is a number before converting the string to int
            Console.WriteLine("Enter another number");
            userInput = Console.ReadLine();
            validateNumber(userInput);
            number2 = Convert.ToInt32(userInput);

            //Reads user selection and validates it is 1, 2, 3, or 4 before converting the string to int and proceeding with the selected operation
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Press 1 if you want to Add");
            Console.WriteLine("Press 2 if you want to Subtract");
            Console.WriteLine("Press 3 if you want to Multiply");
            Console.WriteLine("Press 4 if you want to Divide");
            userInput = Console.ReadLine();
            validateOperationSelection(userInput);
            userSelectedMathOperation = Convert.ToInt32(userInput);

            switch (userSelectedMathOperation)
            {
                case 1:
                    result = number1 + number2;
                    Console.WriteLine("You chose to add " + number1 + " and " + number2 + ".  The result is: " + result);
                    break;
                case 2:
                    result = number1 - number2;
                    Console.WriteLine("You chose to subtract " + number1 + " and " + number2 + ".  The result is: " + result);
                    break;
                case 3:
                    result = number1 * number2;
                    Console.WriteLine("You chose to multiply " + number1 + " and " + number2 + ".  The result is: " + result);
                    break;
                case 4:
                    result = number1 / number2;
                    Console.WriteLine("You chose to divide " + number1 + " and " + number2 + ".  The result is: " + result);
                    break;

            }

            Console.ReadLine();
        }

        private static void validateOperationSelection(string userInput)
        {
            bool isValidInput = false;
            int x;
            while (isValidInput == false)
            {
                if (int.TryParse(userInput, out x) && x <= 4 && x >= 1)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Error.  Please enter 1, 2, 3, or 4");
                    isValidInput = false;
                    userInput = Console.ReadLine();
                }
            }
        }

        private static void validateNumber(string userInput)
        {
            bool isValidInput = false;
            int x;
            while (isValidInput == false)
            {
                if (int.TryParse(userInput, out x))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Error.  Please enter a number.");
                    isValidInput = false;
                    userInput = Console.ReadLine();
                }
            }
        }

        private static void writeWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Super Basic Calculator");
            Console.WriteLine("Here's how it works:");
            Console.WriteLine("1) Enter a number, 2) enter another number, 3) select an operation, 4) be amazed");
            Console.WriteLine("Press Enter when you're ready to continue");
            Console.ReadLine();
        }
    }
}
