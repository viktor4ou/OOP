
namespace Exceptions_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadNumber(1, 100);

        }

        static void ReadNumber(int start, int end)
        {
            int[] validNumbers = new int[10];

            int validNumbersCount = 0;
            validNumbers[0] = start;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());

                    if (number <= validNumbers.Max() || number >= end)
                    {
                        i--;
                        throw new ArgumentException($"Your number is not in range {validNumbers.Max()} - {end}!");
                    }
                    validNumbers[i] = number;

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;

                }


            }

            Console.WriteLine(String.Join(", ", validNumbers));
        }
    }
}
