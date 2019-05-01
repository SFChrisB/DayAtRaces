using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Guy
    {
        public string Name;         //The guys name
        public Bet MyBet;           //An instance of Bet that has his bet
        public int Cash;            //How much money the guy has.

        //The last two fields are the guys GUI fields on the form
        public RadioButton myRadioButton;
        public Label myLabel;

        public void UpdateLabels()
        {
            //radio button to show my cash. ("Joe has 43 bucks")
            myRadioButton.Text = Name + " has " + Cash + " bucks";

            if (Cash < 5)
            {
                myLabel.Text = Name + " hasn't got enough to bet";
                return;
            }

            //Set my label to my bets description, and the label on my
            if (MyBet != null) myLabel.Text = MyBet.GetDescription();
            else myLabel.Text = Name + " hasn't placed a bet";

        }

        public void ClearBet()
        {
            //Reset my Bet so its zero.
            MyBet = new Bet() { Amount = 0, Bettor = this };
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            //Place a new bet and store it in my bet field
            MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };

            //Return true if the guy had enough money to bet
            if (Cash >= BetAmount)
            {
                UpdateLabels();
                return true;
            }
            else
            {
                ClearBet();
                UpdateLabels();
                return false;
            }
        }

        public void Collect(int Winner)
        {
            int winnings;

            //return null if no bet was placed.
            if (MyBet == null)
            {
                return;
            }

            //Ask my bet to pay out, clear my bet, and update my labels
            winnings = MyBet.PayOut(Winner);
            Cash += winnings;
            ClearBet();
            UpdateLabels();
        }


    }
}
