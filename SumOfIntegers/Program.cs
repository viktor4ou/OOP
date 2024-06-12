using System.Runtime.InteropServices;

namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            int currentNumber = 0;
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    currentNumber = int.Parse(input[i]);
                    sum += currentNumber;

                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{input[i]}' is out of range!");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }   
    }
}
