using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Models
{
    public class Card
    {
        private string face;
        private string suit;
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face
        {
            get => face;
            private set
            {
                if (!_validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }

        }
        public string Suit
        {
            get => suit;
            private set
            {
                if (!_validSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                if (value == "S")
                {
                    suit = "\u2660";
                }
                else if (value == "C")
                {
                    suit = "\u2663";
                }
                else if (value == "D")
                {
                    suit = "\u2666";
                }
                else if (value == "H")
                {
                    suit = "\u2665";
                }
            }
        }

        private IReadOnlyCollection<string> _validFaces =
            new HashSet<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private IReadOnlyCollection<string> _validSuits =
            new HashSet<string>() { "C", "D", "H", "S" };
        public override string ToString()
        {
            return $"[{face}{suit}]";
        }

    }
}