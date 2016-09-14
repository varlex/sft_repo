using System;
using System.Collections.Generic;

namespace prime_finder
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> result = new List<int>();
            result = getPrimes(1000000);
            result = getCircularPrimes(result);
            Console.WriteLine(result.Count);
        }

        public static List<int> getPrimes(int num)
        {

            List<int> solution = new List<int>();
            for (int i = 2; i < num; i++)
            {
                if (i % 2 == 0 && i != 2) { }
                else
                {
                    if (chkPrime(i))
                    {
                        solution.Add(i);
                    }
                }
            }
            return solution;
        }

        public static bool chkPrime(double number)
        {

            if (number == 1)
                return false;
            if (number == 2)
                return true;
            for (int i = 2; i < number; ++i)
            {
                if ((number % i) == 0)
                    return false;
            }
            return true;
        }

        public static List<int> getCircularPrimes(List<int> primesList)
        {
            
            List<int> solution = new List<int>();
            for (int i = 0; i < primesList.Count; i++)
            {
                double num = primesList[i];
                if (primesList[i] < 10)
                {
                    solution.Add(primesList[i]);
                }
                else if (primesList[i].ToString().Contains("2") || primesList[i].ToString().Contains("4") || primesList[i].ToString().Contains("6") || primesList[i].ToString().Contains("8") || primesList[i].ToString().Contains("0") || primesList[i].ToString().Contains("5"))
                {
                  
                }
                else
                {
                    bool isCircularPrime = true;
                    for (int j = 0; j < primesList[i].ToString().Length; j++)
                    {
                        num = Rotate(num, primesList[i].ToString().Length);
                        if(!chkPrime(num))
                        {
                            isCircularPrime = false;
                        }
                    }
                    if (isCircularPrime)
                    {
                        solution.Add(primesList[i]);
                    }
                }
            }
            return solution;
        }

        public static double Rotate(double number, int numOfDigits)
        {
            double givenNo = number;
            int reminder = (int)number % 10;
            int quotient = (int)number / 10;
            return ((reminder * Math.Pow(10, numOfDigits - 1)) + quotient);
        }
    }
}
