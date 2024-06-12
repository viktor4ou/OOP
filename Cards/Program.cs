using Cards.Models;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Card> cards = new();

            string[] inputCards = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputCards.Length; i++)
            {
                string [] currentCard = inputCards[i].Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string face = currentCard[0];
                string suit = currentCard[1];
                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(String.Join(" ",cards));
        }

    }

}
