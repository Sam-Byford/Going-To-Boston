/* Author - Sam Byford
 * 23/11/17 - Created Dice class to generate random numbers for the dice
*/
using System;

namespace Assessment_3
{
    //Class which generates random numbers, between 1 and 6, (dice) and then returns them
    //class Dice
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
}
