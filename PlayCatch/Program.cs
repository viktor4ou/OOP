using System;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int exceptionsCaught = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                try
                {
                    if (action == "Replace")
                    {
                        int index = int.Parse(tokens[1]);
                        if (index < 0 || index > numbers.Length)
                        {
                            throw new IndexOutOfRangeException();
                        }

                        int element;
                        bool canParse = int.TryParse(tokens[2], out element);
                        if (!canParse)
                        {
                            throw new FormatException();
                        }
                        numbers[index] = element;

                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        if (startIndex < 0 || endIndex > numbers.Length)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        List<int> numbersList = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            numbersList.Add(numbers[i]);
                        }
                        Console.WriteLine(String.Join(", ", numbersList));

                    }
                    else if (action == "Show")
                    {
                        int index = int.Parse(tokens[1]);
                        if (index < 0 || index > numbers.Length)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        Console.WriteLine(numbers[index]);

                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCaught++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCaught++;
                }

                if (exceptionsCaught == 3)
                {
                    break;
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
