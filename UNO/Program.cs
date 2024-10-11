using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UNO
{
    class Program
    {
        public static List<Cards> UnshuffledDeck = Create_Deck.Deckbuilder();
        public static List<Cards> ShuffledDeck = new List<Cards>();
        public static List<Cards> PlayedDeck = new List<Cards>();
        public static List<Players> Playerlist = new List<Players>();

        static int numberofplayers;
        public static int currentplayer = 0;
        public static int gamedirection = 0;
        static void Main(string[] args)
        {           
            ShuffleDeck();

            Console.Write("Enter number of players: ");
            string getplayernum = Console.ReadLine();

            while(getplayernum != "2" && getplayernum != "3" && getplayernum != "4" && getplayernum != "5" && getplayernum != "6" && getplayernum != "7" && getplayernum != "8" && getplayernum != "9" && getplayernum != "10")
            {
                Console.Write("Please enter a number between 2 and 10: ");
                getplayernum = Console.ReadLine();
            }
            numberofplayers = int.Parse(getplayernum);

            Console.WriteLine("Number of players: " + numberofplayers);

            for(int i = 0; i<numberofplayers; i++)
            {
                Console.Write("Enter name for player " + (i + 1) + ": ");
                string name = Console.ReadLine();

                Playerlist.Add(new Players()
                {
                    playernumber = (i + 1),
                    playername = name,
                    playerhand = new List<Cards>(),
                });
            }

            Console.WriteLine("Players: ");
            foreach(Players player in Playerlist)
            {
                Console.WriteLine(player.playernumber + ": " + player.playername);
            }

            for(int i = 0; i<7; i++)
            {
                for(int k = 0; k<numberofplayers; k++)
                {
                    DealCard(k);
                }
            }

            DealFirstCard();

            while(true)
            {
                Console.Clear();
                Players templayer;
                Cards playedcard;
                Playhand.Play(Playerlist[currentplayer].playername, PlayedDeck[PlayedDeck.Count - 1], Playerlist[currentplayer], gamedirection, out gamedirection, out templayer, out playedcard);
                Playerlist[currentplayer] = templayer;
                PlayedDeck.Add(playedcard);
                if (Playerlist[currentplayer].playerhand.Count == 0)
                {
                    Console.WriteLine("UNO! \nPlayer" + (currentplayer + 1) + " wins!");
                    break;
                }
                else if(gamedirection == 0)
                {
                    currentplayer++;
                    if(currentplayer == numberofplayers)
                    {
                        currentplayer = 0;
                    }
                }
                else if (gamedirection == 1)
                {
                    currentplayer--;
                    if (currentplayer == -1)
                    {
                        currentplayer = numberofplayers - 1;
                    }
                }

            }


            Console.Write("\n\nPress any key to finish:");
            Console.ReadKey();
        }

        static void DealCard(int playernumber)
        {
            Playerlist[playernumber].playerhand.Add(ShuffledDeck[0]);
            ShuffledDeck.RemoveAt(0);
        }

        static void DealFirstCard()
        {
            Cards firstcard = ShuffledDeck[0];
            if(firstcard.Colour == "black" || firstcard.Effect == "Skip" || firstcard.Effect == "+2" || firstcard.Effect == "Reverse")
            {
                int i = 1;
                while (ShuffledDeck[i].Colour == "black" || ShuffledDeck[i].Effect == "Skip" || ShuffledDeck[i].Effect == "+2" || ShuffledDeck[i].Effect == "Reverse")
                {
                    i++;
                }
                firstcard = ShuffledDeck[i];
                ShuffledDeck.RemoveAt(i);
                PlayedDeck.Add(firstcard);
            }
            else
            {
                ShuffledDeck.RemoveAt(0);
                PlayedDeck.Add(firstcard);
            }
        }

        static void ShuffleDeck()
        {
            Random random = new Random();
            List<int> order = new List<int>();
            List<int> shuffledorder = new List<int>();
            for (int i = 0; i < 108; i++)
            {
                order.Add(i);
            }
            for(int i = 0; i<108; i++)
            {
                int k = random.Next(0, order.Count());
                shuffledorder.Add(order[k]);
                order.RemoveAt(k);               
            }

            for(int i = 0; i< 108; i++)
            {
                ShuffledDeck.Add(UnshuffledDeck[shuffledorder[i]]);
            }
        }

        static void SetConsoleColour(string colour)
        {
            if(colour == "Blue")
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
