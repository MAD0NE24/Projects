using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    public class Playhand
    {
        public static void Play(string currentplayer, Cards currentcard, Players Player, int gamedirection, out int newdirection, out Players temp, out Cards playedcard)
        {
            temp = Player;

            Console.Write("Current Card: ");
            SetConsoleColour(currentcard.Colour);
            Console.Write(currentcard.Colour + " " + currentcard.Effect);
            Console.ResetColor();

            Console.WriteLine("\n\nPlayer " + currentplayer + " hand:\n");

            for (int i = 0;i<temp.playerhand.Count;i++)
            {
                Console.Write((i + 1) + ": ");
                SetConsoleColour(temp.playerhand[i].Colour);
                Console.Write(temp.playerhand[i].Colour + " " + temp.playerhand[i].Effect + "\n");
                Console.ResetColor();
            }
            int card = 0;
            bool playcard = false;
            while (playcard == false)
            {
                card = choosecard(temp);
                playcard = isplayable(currentcard, Player.playerhand[card - 1]);
            }

            
            playedcard = temp.playerhand[card - 1];
            temp.playerhand.RemoveAt(card - 1);

            newdirection = gamedirection;
        }

        static int choosecard(Players temp)
        {
            int card = 0;
            Console.Write("\nPick card to play: ");
            string pickcard = Console.ReadLine();

            try
            {
                card = int.Parse(pickcard);
            }
            catch
            {
                Console.WriteLine("Invalid Entry");
            }
            while (card < 1 || card > temp.playerhand.Count)
            {
                Console.Write("Please enter a number between 1 and " + temp.playerhand.Count + ": ");
                pickcard = Console.ReadLine();
                try
                {
                    card = int.Parse(pickcard);
                }
                catch
                {
                    Console.WriteLine("Invalid Entry");
                }
            }

            return card;
        }

        static bool isplayable(Cards currentcard, Cards newcard)
        {
            bool playable = false;

            if(currentcard.Colour == newcard.Colour || currentcard.Effect == newcard.Effect || newcard.Colour == "black")
            {
                playable = true;
            }

            return playable;
        }

        static void SetConsoleColour(string colour)
        {
            if (colour == "Blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (colour == "Red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (colour == "Yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (colour == "Green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
