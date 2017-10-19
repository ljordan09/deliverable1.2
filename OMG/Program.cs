using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMG
{
    class Program
    {
        static void Main(string[] args)
        {
            UserPrompts();
            Console.ReadLine();
        }
 
        public static int DataCheck(String somethingNew, int? firstInput = null)//This function is designed to validate the data received from the user
        {
            int value = 0;
            bool validate = false;
            while (!validate)
            {
                Console.WriteLine(somethingNew);
                if (!int.TryParse(firstInput, out value))//program crashes here i believe.
                {
                    Console.WriteLine("Invalid entry: you must enter a valid integer. Try again: ");
                }
                else if (firstInput != null && (firstInput.ToString().Length != value.ToString().Length))
                {
                    Console.WriteLine("Invalid entry: This integer has to have the same number of digits as the first" + firstInput.ToString().Length);
                }
                else
                {
                    validate = true;
                }
            }
            return value;
        }
        public static bool Arithmetic(int firstInput, int secondInput)//This function is designed to perform the arithmetic of the program
        {
            int check1;
            int check2;
            int? sumNumber = null;

            for (int i = 0; i <= firstInput.ToString().Length; i++)
            {
                if (i == 0)
                {
                    check1 = firstInput % 10;
                    check2 = secondInput % 10;
                    sumNumber = check2 + check1;
                }
                else
                {
                    check1 = (firstInput) % 10;
                    check2 = (secondInput) % 10;
                    if (!(sumNumber != null && sumNumber == (check2 + check1)))
                    {
                        return false;
                    }
                }
                firstInput = firstInput / 10;
                secondInput = secondInput / 10;

            }
            return true;
        }   
        public static void UserPrompts()// This function is designed to gain information from the user

        {   
            bool result;
            bool repeat = false;
            string doAgain = string.Empty;

            do
            {
                Console.WriteLine("Please enter an integer: ");
                int firstInput = int.Parse(Console.ReadLine());//if i type in anything but a number: System.FormatException: 'Input string was not in a correct format.'
                                                               //if i remove the int.Parse and accept the input as a string the parameters in my call to 'Anything' function error. 

                Console.WriteLine("Please enter another integer with the same number of digits: ");
                int secondInput = int.Parse(Console.ReadLine());//if i type in anything but a number: System.FormatException: 'Input string was not in a correct format.'
                                                                //if i remove the int.Parse and accept the input as a string the parameters in my call to 'Anything' function error. 
                Console.ReadLine();
                result = Arithmetic(secondInput, firstInput);
                Console.WriteLine(result);

                Console.WriteLine("Would you like to run the program again? (yes or no");

                if (doAgain.ToUpper() == "YES" || doAgain.ToLower() == "Yes" || doAgain.ToLower() == "yes")
                    repeat = true;

                else if (doAgain.ToUpper() == "NO" || doAgain.ToLower() == "No" || doAgain.ToLower() == "no")
                {       
                    repeat = false;
                }
                else
                {
                    repeat = false;
                }
                doAgain = Console.ReadLine();

            } while (repeat);

            Console.ReadKey();
        }

    }           
}
