using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Bet
    {
        public int Amount;      //The amount of cash that was bet
        public int Dog;         //The number of the dog that was bet on
        public Guy Bettor;      //The guy who placed the bet

        public string GetDescription()
        {
            string description;
            //Return a string that says who placed the bet, how much cash
            //was bet, and which dog he bet on. ("Joe bets 8 on dog#4")
            //If the amount was zero, no bet was placed. ("Joe hasnt placed a bet")
            if (Amount == 0)
            {
                description = Bettor.Name + " hasn't placed a bet";
                return description;
            } else
            {
                description = Bettor.Name + " bets " + Amount + " on dog #" + Dog;
                return description;
            }
        }

        public int PayOut(int Winner)
        {
            //return Winner;
            //The parameter is the winner of the race. If the dog won,
            //return the amount bet. Otherwise return the negative of the amount bet.
            if (Dog == Winner)
            {
                return Amount * 2;
            }
            else
            {
                return -Amount;
            }
        }
    }
}
