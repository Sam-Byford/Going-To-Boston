/* Author - Sam Byford
 * 23/11/17 - Created Dice class to generate random numbers for the dice
 * 23/11/17 - Created Main method inside of 'Entry' class to house bulk of main code
 * 23/11/17 - Created Player class to generate each players dice, work out the highest value and the return it to the main code
 * 25/11/17 - restart feature implemented, main code switched to 'Game' class, restart method created, Main method now calls Game class 
 * 25/11/17 - Game class created with match play only
 * 28/11/17 - Score play implemented
 * 29/11/17 - One player mode added
 * 1/12/17 - Validation added
 * 1/12/17 - Created validation class to validate user input
*/
using System;
using System.Threading;
using System.Linq;

namespace Assessment_3
{
    class Entry
    {
        //main method that links to console
        static void Main(string[] args)
        {
            //initialises Game class allowing the core code to run
            Game.Program();
        }

        //restart feature implemented through the restart method. 'over' passed to this method from Game class
        public static bool Restart(ref bool over)
        {
            //over set to true. (purpose of this explained in Game class)
            over = true;
            //Any color changes the console may have picked up from Game class are reset
            Console.ResetColor();
            //input from the user is registered 
            Console.WriteLine("\nPress 'r' to restart or press any other key to close the application ");
            ConsoleKeyInfo input = Console.ReadKey();

            /*if statement to check if the user has entered 'r' to restart or another key to close the game
             *if 'r' is clicked the console is cleared of all text and the Game class is relaunched
             *if any other key is clicked a goodbye message is displayed and the program exists
            */
            if (input.KeyChar == 'r')
            {
                Console.Clear();
                /*Thread.sleep is used across the program to slow sections of it down. 
                 *This improves the flow of the program and gives it a more controlled and professional feel
                */
                Thread.Sleep(1000);
                Game.Program();
            }
            else
            {
                Console.WriteLine("\n**********Thank you for playing!**********");
                Thread.Sleep(2000);
            }
            //over value returned
            Console.ReadLine();
            return (over);

        }
    }
    //Class where the game itself is created
    class Game
    {
        //Main program
        public static void Program()
        {
            //Player class intialised
            Player player = new Player();
            Console.WriteLine("\n\t---Going to Boston---");
            Thread.Sleep(2000);
            /*creates a variable which stores the result of the 'gameModeVal' method from the 'validation' class 
            * Asks the user which gamemode they would like to play then returns the result 
            * Explained in more detail later on
            */
            string gamemode = Validation.gameModeVal();
            /*asks the user how many people they would like to play with by calling the 'numberOfPlayerVal' method from the 'validation' class 
            *The question is asked in the method and the result is then returned
            * Exaplined in more detail later on
            */
            int noplayers = Validation.numberOfPlayersVal();
            //If statement checks response to above question. If the user has selected 2 players this section is run
            if (noplayers == 2)
            {
                /*If the user selected 'match play' this section is run.
                 *'Or' operator used to allow the user to enter either input types without an error 
                */
                if ((gamemode == "MATCH PLAY") || (gamemode == "MATCHPLAY"))
                {
                    //roundno, player 1 and player 2 overall score and stopgame are set to default values
                    int roundno = 1;
                    int p1roundswon = 0;
                    int p2roundswon = 0;
                    bool stopgame = false;
                    //console cleared and message is displayed telling the user what gamemode they selected
                    Console.Clear();
                    Console.WriteLine("\n       Match Play (2p) selected");
                    Thread.Sleep(2000);
                    //while loop that will loop for as long as stopgame is euqal to false
                    while (stopgame == false)
                    {
                        //console cleared again and 'over' is initialised to false
                        Console.Clear();
                        bool over = false;
                        //round number displayed at the start of each round
                        Console.WriteLine("\n\t****Round {0}****", roundno);
                        //number of dice set to 3 and the scores for the start of the current round are set equal to 0
                        int diceno = 3;
                        int player1 = 0;
                        int player2 = 0;
                        //'score' is the variable which stores the score from the current roll before it is added to the players round score
                        int score = 0;
                        //for loop which loops 3 times to imitiate the 3 rolls the user makes
                        for (int i = 1; i < 4; i++)
                        {
                            //First player 'rolls' their dice by pressing any key. The value they rolled is then displaced to them
                            Console.WriteLine("\nPlayer 1: Press any key to roll your dice");
                            Console.ReadKey();
                            //score for current roll is calcuated by calling the player class and passing the number of dice on the current roll to it
                            score = player.CreatePlayer(diceno);
                            //score for the roll is then added to the score for the current round
                            player1 = player1 + score;
                            Console.Write("\nOn roll");
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

                            //same as the above section but for the second player instead
                            Console.WriteLine("\n\nPlayer 2: any key to roll your dice");
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

                            //number of dice is reduced by 1 each time the loop iterates. This creates the effect of rolling 3 dice, then 2 and then 1
                            diceno--;

                            //if statement triggerd if the players are on their last rolls
                            if (i == 3)
                            {
                                //if statement checks to see if both players scores for the round are equal
                                if (player1 == player2)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine();
                                    /*if the scores are equal the dice are 're-rolled'
                                    *This is done by resetting the number of dice, the players scores for that round and then setting 'i' to 0 to allow the loop to iterate again successfully
                                    */
                                    Console.WriteLine("****The scores are tied. The dice will be re-rolled****");
                                    Console.WriteLine();
                                    i = 0;
                                    diceno = 3;
                                    player1 = 0;
                                    player2 = 0;
                                }
                            }
                        }

                        //if statement to check who has won the round
                        if (player1 > player2)
                        {
                            /*Section if player 1 has beaten player 2 
                            *Outputs each players score for the round and the number of rounds won by each player
                            */
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
                            //checks to see if player 1 has won more than 5 rounds
                            if (p1roundswon >= 5)
                            {
                                //if they have won more than 5 rounds; a congratulatory message is displayed, stopgame is set equal to true and the restart class is called
                                Thread.Sleep(1000);
                                stopgame = true;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("\n\n****player 1 has won the game!****");
                                Entry.Restart(ref over);
                            }
                        }
                        else if (player2 > player1)
                        {
                            //same as the above code but for player 2 instead
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
                        /*if the 'over' value is equal to false, as it will be until the restart fucntion is called, 
                        *a prompt asking the user to press a key to continue will be displayed.
                        * This prevents the message from being displayed when the game is over
                        */
                        if (over == false)
                        {
                            Thread.Sleep(1000);
                            Console.ResetColor();
                            Console.WriteLine("\n\nPress any key to continue");
                            Console.ReadKey();
                            //round number is incremented by 1
                            roundno++;
                        }


                    }
                }


                //SCORE PLAY

                if ((gamemode == "SCORE PLAY") || (gamemode == "SCOREPLAY"))
                {
                    //same code as for match play, except there is now no longer any need for variables to keep track of number of rounds won 
                    Console.Clear();
                    Console.WriteLine("\n      Score Play (2p) selected");
                    Thread.Sleep(2000);
                    bool over = false;
                    int roundno = 1;
                    bool stopgame = false;
                    int player1 = 0;
                    int player2 = 0;
                    while (stopgame == false)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t****Round {0}****", roundno);
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
                        //checks to see if the round number is less than 5
                        if (roundno < 5)
                        {
                            //if the round number is less than 5 the scores after the round are displayed for both players
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
                            //if the round number is 5 the scores after the round are displayed and then they are compared
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
                            //score comparison
                            if (player1 > player2)
                            {
                                //if player 1 score is greater than player 2 score the appropritate message is displayed and stop game is set to true
                                Thread.Sleep(1000);
                                Console.WriteLine("\n\nPlayer 1 has won with a score of {0} and player 2 has lost with a score of {1}", player1, player2);
                                stopgame = true;
                            }
                            else if (player2 > player1)
                            {
                                //same as above code but for player 2 winning instead
                                Thread.Sleep(1000);
                                Console.WriteLine("\n\nPlayer 2 has won the game with a score of {0} and player 1 has lost with a score of {1}", player2, player1);
                                stopgame = true;
                            }
                            else
                            {
                                //if the scores are equal a tied message is displayed
                                Thread.Sleep(1000);
                                Console.WriteLine("\n\nScores are tied!");
                                stopgame = true;

                            }
                        }
                        //resets any colours that may have been set 
                        Console.ResetColor();
                        /*Exactly the same as the if statement at the end of the 'match play' section,
                         *but if the round number is greater than 5 the restart function is automatically called
                        */
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

                    }

                }
                //if the number of players is just 1 the 'OnePlayer' class is called
            }
            else if (noplayers == 1)
            {
                OnePlayer.AI(gamemode);
            }
        }
    }
    class OnePlayer
    {
        public static void AI(string gamemode)
        {
            //player class is initialised 
            Player player = new Player();
            if ((gamemode == "MATCH PLAY") || (gamemode == "MATCHPLAY"))
            {
                /*following code is exactly the same as 2 player match play,
                *except a few variables are changed and some additional features are added
                */
                Console.WriteLine();
                int roundno = 1;
                int p1roundswon = 0;
                //p2roundswon is replaced with 'AIrondswon'
                int AIroundswon = 0;
                bool stopgame = false;
                Console.Clear();
                Console.WriteLine("\n       Match Play (1p) selected");
                Thread.Sleep(2000);

                while (stopgame == false)
                {
                    Console.Clear();
                    bool over = false;
                    Console.WriteLine("\n\t****Round {0}****", roundno);
                    Console.WriteLine();
                    int diceno = 3;
                    int player1 = 0;
                    //player2 is replaced with 'AI'
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

                        //Rather than an input from the user the computers dice are rolled automatically with a time delay to create a better flow
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
                            }
                        }
                    }


                    if (player1 > AI)
                    {
                        Thread.Sleep(1000);
                        Console.Write("\nYou have won the round with a score of ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("{0} ", player1);
                        Console.ResetColor();
                        Console.Write("and the computer has lost it with a score of");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0}", AI);
                        Console.ResetColor();
                        p1roundswon++;
                        Thread.Sleep(1000);
                        Console.Write("\nYou have won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0}", p1roundswon);
                        Console.ResetColor();
                        Console.Write(" rounds and the computer has won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0} ", AIroundswon);
                        Console.ResetColor();
                        Console.Write("round(s)");
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
                        Console.Write("\nYou have lost the round with a score of ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("{0} ", player1);
                        Console.ResetColor();
                        Console.Write("and the computer has won it with a score of");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0}", AI);
                        Console.ResetColor();
                        AIroundswon++;
                        Thread.Sleep(1000);
                        Console.Write("\nYou have won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0}", p1roundswon);
                        Console.ResetColor();
                        Console.Write(" rounds and the computer has won");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0}", AIroundswon);
                        Console.ResetColor();
                        Console.Write(" round(s)");
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
                    }

                }
            }


            //SCORE PLAY

            if ((gamemode == "SCORE PLAY") || (gamemode == "SCOREPLAY"))
            {
                Console.Clear();
                Console.WriteLine("\n      Score Play (1p) selected");
                Thread.Sleep(2000);
                bool over = false;
                int roundno = 1;
                bool stopgame = false;
                int player1 = 0;
                int AI = 0;
                while (stopgame == false)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t****Round {0}****", roundno);
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
                    }
                    else
                    {
                        Entry.Restart(ref over);
                    }
                }

            }
        }
    }
    //class which calls the 'dice' class to create the dice for each player
    class Player
    {
        //new instance of dice class
        Dice die = new Dice();
        //method which generates the dice
        public int CreatePlayer(int diceno)
        {
            //array to store 'x' number of dice. x being whatever value (1-3) is passed from the main code as 'diceno' 
            int[] playerDice = new int[diceno];

            //loops through the array 'x' number of times
            for (int i = 0; i < diceno; i++)
            {
                //on each loop the dice class is called to generate a random number. This number is then stored in the next position, 'i', in the array
                playerDice[i] = die.CreateDie();
            }
            //the max value of the array is then calcuated and returned. This is equivilant to choosing the highest value from the rolled dice and setting it aside
            int maxValue = playerDice.Max();

            return (maxValue);
        }

    }
    //Class which generates random numbers, between 1 and 6, (dice) and then returns them
    class Dice
    {
        //creates new instance of the random class
        Random rnd = new Random();
        //method that generates the numbers
        public int CreateDie()
        {
            //creates random number using the random class and the '.Next' method
            int num = rnd.Next(1, 7);
            //returns number
            return (num);
        }
    }
    /*Class which checks various data that has been inputted by the user
    *Instead of 'try' and 'catch' statements this class uses simple if statements
    *Prevents most exceptions from occuring without need for long winded, multiple, catch statements
    *
   */
    class Validation
    {
        //method checks the gamemode the user has entered 
        public static string gameModeVal()
        {
            //check variable set up to compare inputted data to expected data. Set to null to start with
            string check = null;
            //bool statement set up to allow while loop to function
            bool validation = false;
            /*This while loop will keep asking the user the question unless they input the desired data and cause,
             * 'validation' to be set to 'true'
            */
            while (validation == false)
            {
                Console.WriteLine("\nWhich game mode would you like to play? 'Match play' or 'Score play'");
                check = Console.ReadLine();
                /*inputted data is set to upper case 
                 *This allows the user to enter various different variations without an error being caused
                 * eg; Match play, Match Play, score play or SCOre PlAy. None of these will cause errors
                */
                check = check.ToUpper();
                if ((check == "MATCH PLAY") || (check == "MATCHPLAY") || (check == "SCORE PLAY") || (check == "SCOREPLAY"))
                {
                    validation = true;
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\nError: Please enter either 'Match play' or 'Score play'");
                    Thread.Sleep(1000);
                }
            }
            //user input returned back to 'Game' class
            return (check);
        }
        //method checks the number of players the user has entered
        public static int numberOfPlayersVal()
        {
            //exactly the same as the above method, except it checks that the user has entered a correct number of players
            string check = null;
            bool validation = false;
            while (validation == false)
            {
                Console.WriteLine("Would you like to play one player or two player?");
                check = Console.ReadLine();

                if ((check == "1") || (check == "2"))
                {
                    validation = true;
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\nError: Please enter either '1' player or '2' player");
                    Thread.Sleep(1000);
                }
            }
            //user input converted to an int and then returned back to 'Game' class
            //converted to int for easier manipulation in the 'Game' class
            int noplayers = Convert.ToInt32(check);
            return (noplayers);
        }
    }

}

