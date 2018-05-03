using System;
using System.Linq;
using System.Threading;

namespace Assessment_3
{
    class Entry
    {
        static void Main(string[] args)
        {
            Game.Program();
        }

        public static bool Restart(ref bool over)
        {
            over = true;
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press 'r' to restart or press any other key to close the application ");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();

            if (input.KeyChar == 'r')
            {
                Console.Clear();
                Thread.Sleep(1000);
                Game.Program();
            }
            else
            {
                Console.WriteLine("**********Thank you for playing!**********");
                Console.ReadLine();
            }
            return (over);
        }
    }

    class Game
    {
        public static void Program()
        {
            Player player = new Player();
            Console.WriteLine("Which game mode would you like to play? 'Match play' or 'Score play'");
            string gamemode = Console.ReadLine();
            Console.WriteLine("Would you like to play one player or two player?");
            int noplayers = Convert.ToInt32(Console.ReadLine());
            gamemode = gamemode.ToUpper();
            if (noplayers == 2)
            {

                if (gamemode == "MATCH PLAY")
                {
                    int roundno = 1;
                    int p1roundswon = 0;
                    int p2roundswon = 0;
                    bool stopgame = false;
                    int check = 0;
                    Console.Clear();
                    Console.WriteLine("\n       Match Play selected");
                    Thread.Sleep(2000);
                    while (stopgame == false)
                    {
                        Console.Clear();
                        bool over = false;
                        if (check == 0)
                        {
                            Console.WriteLine("\n\t****Round {0}****", roundno);
                        }
                        else
                        {
                            Console.WriteLine("\n\t****Round {0}****", roundno);
                        }
                        Console.WriteLine();
                        int diceno = 3;
                        int player1 = 0;
                        int player2 = 0;
                        int score = 0;
                        for (int i = 1; i < 4; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Player 1: Press any key to roll your dice");
                            Console.ReadKey();
                            Console.WriteLine();
                            score = player.CreatePlayer(diceno);
                            player1 = player1 + score;
                            Console.Write("On roll");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0}", i);
                            Console.ResetColor();
                            Console.Write(" The highest value player ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("1 ");
                            Console.ResetColor();
                            Console.Write("has scored is");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0} ", score);
                            Console.ResetColor();
                            Console.WriteLine();

                            Console.WriteLine();
                            Console.WriteLine("Player 2: any key to roll your dice");
                            Console.ReadKey();
                            Console.WriteLine();
                            score = player.CreatePlayer(diceno);
                            player2 = score + player2;
                            Console.Write("On roll");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0}", i);
                            Console.ResetColor();
                            Console.Write(" The highest value player ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("2 ");
                            Console.ResetColor();
                            Console.Write("has scored is");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0} ", score);
                            Console.ResetColor();
                            Console.WriteLine();

                            diceno--;

                            if (i == 3)
                            {
                                if (player1 == player2)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine();
                                    Console.WriteLine("****The scores are tied. The dice will be re-rolled****");
                                    Console.WriteLine();
                                    i = 0;
                                    diceno = 3;
                                    player1 = 0;
                                    player2 = 0;
                                    score = 0;
                                }
                            }
                        }

                        if (player1 > player2)
                        {
                            Thread.Sleep(1000);
                            Console.Write("\nPlayer 1 has won the round with a score of ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("{0} ", player1);
                            Console.ResetColor();
                            Console.Write("and player 2 has lost it with a score of");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", player2);
                            Console.ResetColor();
                            p1roundswon++;
                            Thread.Sleep(1000);
                            Console.Write("\nPlayer 1 has won");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0}", p1roundswon);
                            Console.ResetColor();
                            Console.Write(" round(s) and the player 2 has won");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", p2roundswon);
                            Console.ResetColor();
                            Console.Write("round(s)");
                            Console.ResetColor();
                            if (p1roundswon >= 5)
                            {
                                Thread.Sleep(1000);
                                stopgame = true;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("\n\n****player 1 has won the game!****");
                                Entry.Restart(ref over);
                            }
                        }
                        else if (player2 > player1)
                        {
                            Thread.Sleep(1000);
                            Console.Write("\nPlayer 2 has won the round with a score of");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", player2);
                            Console.ResetColor();
                            Console.Write("and player 1 has lost it with a score of");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", player1);
                            Console.ResetColor();
                            p2roundswon++;
                            Thread.Sleep(1000);
                            Console.Write("\nPlayer 1 has won");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0}", p1roundswon);
                            Console.ResetColor();
                            Console.Write(" round(s) and the player 2 has won");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0}", p2roundswon);
                            Console.ResetColor();
                            Console.Write(" round(s)");
                            if (p2roundswon >= 5)
                            {
                                Thread.Sleep(1000);
                                stopgame = true;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("\n\n****player 2 has won the game!****");
                                Entry.Restart(ref over);
                            }
                        }

                        if (over == false)
                        {
                            Thread.Sleep(1000);
                            Console.ResetColor();
                            Console.WriteLine("\n\nPress any key to continue");
                            Console.ReadKey();
                            roundno++;
                        }
                        
                        check++;
                    }
                }


                //SCORE PLAY

                if (gamemode == "SCORE PLAY")
                {
                    Console.Clear();
                    Console.WriteLine("\n      Score Play selected");
                    Thread.Sleep(2000);
                    bool over = false;
                    int roundno = 1;
                    bool stopgame = false;
                    int player1 = 0;
                    int player2 = 0;
                    int check = 0;
                    while (stopgame == false)
                    {
                        Console.Clear();
                        if (check == 0)
                        {
                            Console.WriteLine("\n\t****Round {0}****", roundno);
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t****Round {0}****", roundno);
                        }
                       
                        Console.WriteLine();
                        int diceno = 3;
                        int score = 0;

                        for (int i = 1; i < 4; i++)
                        {
                            Console.WriteLine("\nPlayer 1: Press any key to roll your dice");
                            Console.ReadKey();
                            score = player.CreatePlayer(diceno);
                            player1 = player1 + score;
                            Console.Write("\nOn roll");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0}", i);
                            Console.ResetColor();
                            Console.Write(" The highest value player");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" 1 ");
                            Console.ResetColor();
                            Console.Write("rolled is");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0} ", score);
                            Console.ResetColor();
                            Console.WriteLine();

                            Console.WriteLine("\nPlayer 2: Press any key to roll your dice");
                            Console.ReadKey();
                            Console.WriteLine();
                            score = player.CreatePlayer(diceno);
                            player2 = score + player2;
                            Console.Write("On roll");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0}", i);
                            Console.ResetColor();
                            Console.Write(" The highest value player");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" 2 ");
                            Console.ResetColor();
                            Console.Write("rolled is");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0} ", score);
                            Console.ResetColor();
                            Console.WriteLine();

                            diceno--;
                        }

                        if (roundno < 5)
                        {
                            Thread.Sleep(2000);
                            Console.Write("\nAfter round");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", roundno);
                            Console.ResetColor();
                            Console.Write("player 1 has scored");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", player1);
                            Console.ResetColor();
                            Console.Write("and player 2 has scored");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0}", player2);
                            Console.ResetColor();
                        }
                        else
                        {
                            Thread.Sleep(2000);
                            Console.Write("\nAfter round");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", roundno);
                            Console.ResetColor();
                            Console.Write("player 1 has scored");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0} ", player1);
                            Console.ResetColor();
                            Console.Write("and player 2 has scored");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" {0}", player2);
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            if (player1 > player2)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("\n\nPlayer 1 has won with a score of {0} and player 2 has lost with a score of {1}", player1, player2);
                                stopgame = true;
                            }
                            else if (player2 > player1)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("\n\nPlayer 2 has won the game with a score of {0} and player 1 has lost with a score of {1}", player2, player1);
                                stopgame = true;
                            }
                            else
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("\n\nScores are tied!");

                            }
                        }

                        Console.ResetColor();
                        if (roundno < 5)
                        {
                            Thread.Sleep(1000);
                            Console.Write("\n\nPress any key to continue");
                            Console.ReadKey();
                            roundno++;
                            
                        }
                        else
                        {
                            Entry.Restart(ref over);
                        }
                        check++;
                    }

                }

                else
                {
                    Console.WriteLine("Please enter either 'score play' or 'match play'");
                    Console.ReadLine();
                }
            }
            else if (noplayers==1)
            {
                OnePlayer.AI(gamemode);
                
            }
        }


    }

    class Dice
    {
        Random rnd = new Random();
        public int CreateDie()
        {
            int num = rnd.Next(1, 7);
            return (num);
        }
    }

    class Player
    {
        Dice die = new Dice();
        public int CreatePlayer(int diceno)
        {
            int[] playerDice = new int[diceno];
            for (int i = 0; i < diceno; i++)
            {
                playerDice[i] = die.CreateDie();
            }
            int maxValue = playerDice.Max();
            return (maxValue);
        }

    }

    class OnePlayer 
    {
        public static void AI(string gamemode)
        {
            Player player = new Player();
            if (gamemode == "MATCH PLAY")
            {
                Console.WriteLine();
                int roundno = 1;
                int p1roundswon = 0;
                int AIroundswon = 0;
                int check = 0;
                bool stopgame = false;
                Console.Clear();
                Console.WriteLine("\n       Match Play selected");
                Thread.Sleep(2000);

                while (stopgame == false)
                {
                    Console.Clear();
                    bool over = false;
                    if (check == 0)
                    {
                        Console.WriteLine("\n\t****Round {0}****", roundno);
                    }
                    else
                    {
                        Console.WriteLine("\n\n\t****Round {0}****", roundno);
                    }
                    Console.WriteLine();
                    int diceno = 3;
                    int player1 = 0;
                    int AI = 0;
                    int score = 0;
                    for (int i = 1; i < 4; i++)
                    {
                        Console.WriteLine("\n Press any key to roll your dice");
                        Console.ReadKey();
                        Console.WriteLine();
                        score = player.CreatePlayer(diceno);
                        player1 = player1 + score;
                        Console.Write("On roll");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" {0}", i);
                        Console.ResetColor();
                        Console.Write(" The highest value you rolled is ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("{0}", score);
                        Console.ResetColor();

                        Thread.Sleep(2000);
                        Console.WriteLine("\n\nThe computer will now roll their dice");
                        Thread.Sleep(2000);
                        score = player.CreatePlayer(diceno);
                        AI = score + AI;
                        Console.Write("\nOn roll");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" {0}", i);
                        Console.ResetColor();
                        Console.Write(" The highest value the computer rolled is ");
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("{0}", score);
                        Console.ResetColor();
                        Console.WriteLine();

                        diceno--;

                        if (i == 3)
                        {
                            if (player1 == AI)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("\n****The scores are tied. The dice will be re-rolled****");
                                Console.WriteLine();
                                i = 0;
                                diceno = 3;
                                player1 = 0;
                                AI = 0;
                                score = 0;
                            }
                        }
                    }

                    
                    if (player1 > AI)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("\nYou have won the round with a score of");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0}", player1);
                        Console.ResetColor();
                        Console.WriteLine("and the computer has lost it with a score of");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0}", AIroundswon);
                        Console.ResetColor();
                        p1roundswon++;
                        Thread.Sleep(1000);
                        Console.WriteLine("You have won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0}", p1roundswon);
                        Console.ResetColor();
                        Console.WriteLine(" rounds and the computer has won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0} ", AIroundswon);
                        Console.ResetColor();
                        Console.WriteLine("round(s)");
                        if (p1roundswon >= 5)
                        {
                            Thread.Sleep(1000);
                            stopgame = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\n\n****You have has won the game!****");
                            Console.ResetColor();
                            Entry.Restart(ref over);
                        }
                    }
                    else if (AI > player1)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("\nYou have lost the round with a score of");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0}", player1);
                        Console.ResetColor();
                        Console.WriteLine("and the computer has won it with a score of");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0}", AIroundswon);
                        Console.ResetColor();
                        AI++;
                        Thread.Sleep(1000);
                        Console.WriteLine("You have won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0}", p1roundswon);
                        Console.ResetColor();
                        Console.WriteLine(" rounds and the computer has won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("{0}", AIroundswon);
                        Console.ResetColor();
                        if (AIroundswon >= 5)
                        {
                            Thread.Sleep(1000);
                            stopgame = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\n\n****Unlucky! The computer has won the game!****");
                            Console.ResetColor();
                            Entry.Restart(ref over);
                        }
                    }

                    if (over == false)
                    {
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.WriteLine("\n\nPress any key to continue\n");
                        Console.ReadKey();
                        roundno++;
                        check++;
                    }

                }
            }


            //SCORE PLAY

            if (gamemode == "SCORE PLAY")
            {
                Console.Clear();
                Console.WriteLine("\n      Score Play selected");
                Thread.Sleep(2000);
                bool over = false;
                int roundno = 1;
                bool stopgame = false;
                int player1 = 0;
                int AI = 0;
                int check = 0;
                while (stopgame == false)
                {
                    Console.Clear();
                    if (check == 0)
                    {
                        Console.WriteLine("\n\t****Round {0}****", roundno);
                    }
                    else
                    {
                        Console.WriteLine("\n\n\t****Round {0}****", roundno);
                    }
                    Console.WriteLine();
                    int diceno = 3;
                    int score = 0;

                    for (int i = 1; i < 4; i++)
                    {
                        Console.WriteLine("\nPress any key to roll your dice");
                        Console.ReadKey();
                        score = player.CreatePlayer(diceno);
                        player1 = player1 + score;
                        Console.Write("\nOn roll");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" {0}", i);
                        Console.ResetColor();
                        Console.Write(" The highest value you rolled is ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("{0} ", score);
                        Console.ResetColor();

                        Thread.Sleep(2000);
                        Console.WriteLine("\n\nThe computer will now roll their dice");
                        Thread.Sleep(2000);
                        score = player.CreatePlayer(diceno);
                        AI = AI + score;
                        Console.Write("\nOn roll");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" {0}", i);
                        Console.ResetColor();
                        Console.Write(" The highest value the computer rolled is ");
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("{0} ", score);
                        Console.ResetColor();
                        Console.WriteLine();

                        diceno--;
                    }

                    if (roundno < 5)
                    {
                        Thread.Sleep(2000);
                        Console.Write("\nAfter round");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0} ", roundno);
                        Console.ResetColor();
                        Console.Write("you have scored");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0} ", player1);
                        Console.ResetColor();
                        Console.Write("and the computer has scored");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0}", AI);
                        Console.ResetColor();
                    }
                    else
                    {
                        Thread.Sleep(2000);
                        Console.Write("\nAfter round");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0} ", roundno);
                        Console.ResetColor();
                        Console.Write("you have scored");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0} ", player1);
                        Console.ResetColor();
                        Console.Write("and the computer has scored");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0}", AI);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (player1 > AI)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("\n\nYou have won with a score of {0} and the computer has lost with a score of {1}", player1, AI);
                            stopgame = true;
                        }
                        else if (AI > player1)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("\n\nThe computer has won the game with a score of {0} and you have lost with a score of {1}", AI, player1);
                            stopgame = true;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("\n\nScores are tied!");

                        }
                    }

                    Console.ResetColor();
                    if (roundno < 5)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("\n\nPress any key to continue\n");
                        Console.ReadKey();
                        roundno++;
                        check++;
                    }
                    else
                    {
                        Entry.Restart(ref over);
                    }
                }

            }

            else
            {
                Console.WriteLine("Please enter either 'score play' or 'match play'");
                Console.ReadLine();
            }
        }
    }

}