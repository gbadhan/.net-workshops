using System;

namespace NumberWorder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please pass a positive number as argument. Usage example: NumberWorder.exe 1234");
            }
            else
            {
                string inputArgument = args[0];
                long input;
                
                if (long.TryParse(inputArgument, out input))
                {
                    if (input < 0)
                    {
                        Console.WriteLine("The argument can only be a positive number");
                    }
                    else
                    {
                        int numberOfDigits = inputArgument.Length;
                        string[] numberArray = new string[numberOfDigits];
                        NumberGenerator generator = new NumberGenerator();
                        numberArray = generator.GetConvertedNumberArray(input, numberArray, numberOfDigits - 1);
                        for (int count = 0; count < numberOfDigits; count++)
                        {
                            Console.Write(numberArray[count]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The argument can only be a positive whole number with max value = 8999999999999999999");
                }
            }
        }
    }
}
