using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Poker
{
    class Game
    {

        public static void DisplayResult(string file)
        {
            int[] player = new int[2];
            try
            {
                string[] hands = File.ReadAllLines(file);
                foreach (string hand in hands)
                {
                    PlayerHand player1 = new PlayerHand(hand.Substring(0, 14));
                    PlayerHand player2 = new PlayerHand(hand.Substring(15));

                    switch (player1.Compare(player2))
                    {
                        case 1:
                            player[0]++;
                            break;
                        case -1:
                            player[1]++;
                            break;
                    }

                }

                for (int i = 0; i < 2; i++)
                    Console.WriteLine("Player " + (i + 1) + ": " + player[i]);
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException )
            {
                Console.WriteLine(file+" is not readable/existed");
            }
           
        }
    }
}
