/* Author - Sam Byford
 * 23/11/17 - Created Main method inside of 'Entry' class to house bulk of main code
 * 25/11/17 - restart feature implemented, main code switched to 'Game' class, restart method created, Main method now calls Game class 
*/
using System;
using System.Threading;

namespace Assessment_3
{
    //First class that is called when code is ran, allows for entry into the program hence the name
    //class Entry
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
            return (over);
        }
    }
}