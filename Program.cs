using System;
using System.Collections.Generic;

namespace PrimeNumberCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prime Number Calculator");
            Console.WriteLine("======================");
            Console.WriteLine("This program calculates all prime numbers less than a given limit.");
            Console.WriteLine();

            int limit = GetValidLimit();
            
            Console.WriteLine($"\nCalculating all prime numbers less than {limit}...");
            
            var primeNumbers = Prime.GetPrimesLessThan(limit);
            
            DisplayResults(primeNumbers);
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static int GetValidLimit()
        {
            int limit;
            bool isValid = false;
            
            do
            {
                Console.Write("Enter the upper limit (must be greater than 1): ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out limit) && limit > 1)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer greater than 1.");
                }
                
            } while (!isValid);
            
            return limit;
        }

        private static void DisplayResults(List<int> primes)
        {
            Console.WriteLine($"\nFound {primes.Count} prime numbers:");
            
            const int numbersPerLine = 10;
            for (int i = 0; i < primes.Count; i++)
            {
                Console.Write($"{primes[i],5}");
                
                if ((i + 1) % numbersPerLine == 0 || i == primes.Count - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}