using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Greyhound
    {
        public int StartingPosition;                //Where my PictureBox starts
        public int RaceTrackLength;                 //How long the racetrack is
        public PictureBox MyPictureBox = null;      //My PictureBox object
        public int Location = 0;                    //My Location on the racetrack
        public Random Randomizer;                   //An instance of Random

        public bool Run()
        {
            //Move forward either 1,2,3 or 4 spaces at random
            int tempMove = Randomizer.Next(4);
            Location += tempMove;

            //Update the position of my PictureBox  on the form like this:
            MyPictureBox.Left = StartingPosition + Location;

            //Return true if I won the race
            if (Location >= RaceTrackLength) return true;
            else return false;
        }

        public void TakeStartingPosition()
        {
            //reset my location to 0 and my PictureBox to starting position.
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }   
}
