using System;
using System.Collections.Generic;

namespace PrimeNumberCalculator
{
  class Program
  {
    static void Main()
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

    private static void DisplayResultsOld1(List<int> primes)
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

    private static void DisplayResults(List<int> primes)
    {
      Console.WriteLine($"\nFound {primes.Count} prime numbers:");

      // Determine the width needed for the largest prime number
      int fieldWidth = 1;
      if (primes.Count > 0)
      {
        // Get the largest prime (last in the list) and calculate its digit length
        int largestPrime = primes[primes.Count - 1];
        fieldWidth = largestPrime.ToString().Length;

        // Add 2 for padding (at least 1 space between numbers)
        fieldWidth += 2;
      }

      const int numbersPerLine = 10;
      for (int i = 0; i < primes.Count; i++)
      {
        // Use the dynamic field width for better alignment
        Console.Write($"{primes[i],0}".PadRight(fieldWidth));

        if ((i + 1) % numbersPerLine == 0 || i == primes.Count - 1)
        {
          Console.WriteLine();
        }
      }
    }
  }
}