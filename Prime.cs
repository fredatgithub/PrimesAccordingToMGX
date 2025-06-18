using System;
using System.Collections.Generic;

namespace PrimeNumberCalculator
{
  public static class Prime
  {
    /// <summary>
    /// Checks if a number is prime
    /// </summary>
    /// <param name="number">The number to check</param>
    /// <returns>True if the number is prime, false otherwise</returns>
    public static bool IsPrime(int number)
    {
      // Handle edge cases
      if (number <= 1)
        return false;

      if (number <= 3)
        return true;

      // Quick check for even numbers
      if (number % 2 == 0)
        return false;

      // Check odd divisors up to the square root
      int boundary = (int)Math.Floor(Math.Sqrt(number));

      for (int i = 3; i <= boundary; i += 2)
      {
        if (number % i == 0)
          return false;
      }

      return true;
    }

    /// <summary>
    /// Gets all prime numbers less than a specified limit using the Sieve of Eratosthenes algorithm
    /// </summary>
    /// <param name="limit">The upper limit</param>
    /// <returns>A list containing all prime numbers less than the limit</returns>
    public static List<int> GetPrimesLessThan(int limit)
    {
      var primes = new List<int>();

      // Handle small limits
      if (limit <= 2)
        return primes;

      // Add 2 as the first prime
      primes.Add(2);

      // For very small limits, we're done
      if (limit <= 3)
        return primes;

      // Use Sieve of Eratosthenes for larger limits
      if (limit >= 1000)
      {
        return SieveOfEratosthenes(limit);
      }

      // For smaller limits, use trial division which is simpler
      for (int i = 3; i < limit; i += 2)
      {
        if (IsPrime(i))
        {
          primes.Add(i);
        }
      }

      return primes;
    }

    /// <summary>
    /// Implements the Sieve of Eratosthenes algorithm for finding primes efficiently
    /// </summary>
    /// <param name="limit">The upper limit</param>
    /// <returns>A list containing all prime numbers less than the limit</returns>
    private static List<int> SieveOfEratosthenes(int limit)
    {
      // Initialize the sieve with all numbers potentially prime
      bool[] isPrime = new bool[limit];
      for (int i = 2; i < limit; i++)
      {
        isPrime[i] = true;
      }

      // Implement the sieve
      for (int i = 2; i * i < limit; i++)
      {
        if (isPrime[i])
        {
          // Mark all multiples of i as non-prime
          for (int j = i * i; j < limit; j += i)
          {
            isPrime[j] = false;
          }
        }
      }

      // Collect the primes into a list
      var primes = new List<int>();
      for (int i = 2; i < limit; i++)
      {
        if (isPrime[i])
        {
          primes.Add(i);
        }
      }

      return primes;
    }
  }
}