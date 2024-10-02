using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class Create_Deck
    {
        public static List<Cards> Deckbuilder()
        {
            List<Cards> Deck = new List<Cards>();

            string[] Colours = new string[] { "Red", "Yellow", "Green", "Blue"};
            int[] Numbers = new int[] {0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9 };
            string[] Coloureffects = new string[] { "Skip", "+2", "Reverse" };

            foreach (string Colour in Colours)
            {
                foreach (int Numer in Numbers)
                {
                    Deck.Add(new Cards()
                    {
                        Colour = Colour,
                        Effect = Numer.ToString(),
                    });
                }
                foreach(string Eff in Coloureffects)
                {
                    Deck.Add(new Cards()
                    {
                        Colour = Colour,
                        Effect = Eff,
                    });
                    Deck.Add(new Cards()
                    {
                        Colour = Colour,
                        Effect = Eff,
                    });
                }

            }
            for(int i = 0; i<4; i++)
            {
                Deck.Add(new Cards()
                {
                    Colour = "Black",
                    Effect = "Wild",
                });
                Deck.Add(new Cards()
                {
                    Colour = "Black",
                    Effect = "Wild +4",
                });
            }

            return Deck;
        }
    }
}
