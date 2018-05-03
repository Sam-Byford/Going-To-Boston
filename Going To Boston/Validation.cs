/* Author - Sam Byford
 * 1/12/17 - Created validation class to validate user input
*/ 
using System;
using System.Threading;

namespace Assessment_3
{
    /*Class which checks various data that has been inputted by the user
     *Instead of 'try' and 'catch' statements this class uses simple if statements
     *Prevents most exceptions from occuring without need for long winded, multiple, catch statements
     *
    */ 
    //class Validation
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
                if ((check == "MATCH PLAY") || (check=="MATCHPLAY") || (check == "SCORE PLAY") || (check=="SCOREPLAY"))
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
