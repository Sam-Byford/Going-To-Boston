/* Author - Sam Byford
 * 23/11/17 - Created Player class to generate each players dice, work out the highest value and the return it to the main code
*/
using System;
using System.Linq;

namespace Assessment_3
{
    //class which calls the 'dice' class to create the dice for each player
    //class Player
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
}
