using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public partial class Form1 : Form
    {
        Greyhound[] greyHoundArray = new Greyhound[4];
        Guy[] guyArray = new Guy[3];
        Random MyRandomizer = new Random();
        int radioButtonSelected = 0;

        public Form1()
        {
            InitializeComponent();

            //Initialising our greyhound array
            greyHoundArray[0] = new Greyhound()
            {
                MyPictureBox = greyhoundPB1,
                StartingPosition = greyhoundPB1.Left,
                RaceTrackLength = racetrackPB.Width - greyhoundPB1.Width,
                Randomizer = MyRandomizer
            };
            greyHoundArray[1] = new Greyhound()
            {
                MyPictureBox = greyhoundPB2,
                StartingPosition = greyhoundPB2.Left,
                RaceTrackLength = racetrackPB.Width - greyhoundPB2.Width,
                Randomizer = MyRandomizer
            };
            greyHoundArray[2] = new Greyhound()
            {
                MyPictureBox = greyhoundPB3,
                StartingPosition = greyhoundPB3.Left,
                RaceTrackLength = racetrackPB.Width - greyhoundPB3.Width,
                Randomizer = MyRandomizer
            };
            greyHoundArray[3] = new Greyhound()
            {
                MyPictureBox = greyhoundPB4,
                StartingPosition = greyhoundPB4.Left,
                RaceTrackLength = racetrackPB.Width - greyhoundPB4.Width,
                Randomizer = MyRandomizer
            };

            //Initialising our Guy Array
            guyArray[0] = new Guy()
            {
                Cash = 50,
                Name = "Joe",
                myLabel = joeBetLabel,
                myRadioButton = joeRadioButton
            };
            guyArray[1] = new Guy()
            {
                Cash = 50,
                Name = "Bob",
                myLabel = bobBetLabel,
                myRadioButton = bobRadioButton
            };
            guyArray[2] = new Guy()
            {
                Cash = 50,
                Name = "Al",
                myLabel = alBetLabel,
                myRadioButton = alRadioButton
            };

            minBetlabel.Text = "Minimum Bet:" + betsNumUD.Minimum;
            nameTextLabel.Text = "Joe";
            guyArray[0].UpdateLabels();
            guyArray[1].UpdateLabels();
            guyArray[2].UpdateLabels();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Run through each dog until a winner has been determined
            for (int i = 0; i < greyHoundArray.Length; i++)
            {
                greyHoundArray[i].Run();
                if (greyHoundArray[i].Run() == true)
                {
                    timer1.Stop();
                    int winner = i + 1;
                    MessageBox.Show("The winning dog was #" + winner);
                    guyArray[0].Collect(winner);
                    guyArray[1].Collect(winner);
                    guyArray[2].Collect(winner);

                    greyHoundArray[0].TakeStartingPosition();
                    greyHoundArray[1].TakeStartingPosition();
                    greyHoundArray[2].TakeStartingPosition();
                    greyHoundArray[3].TakeStartingPosition();
                }

            }
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            //radioButtonSelected: 0 = Joe, 1 = Bob, 2 = Al
            guyArray[radioButtonSelected].PlaceBet((int)betsNumUD.Value, (int)dogsNumUD.Value);

        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSelected = 0;
            nameTextLabel.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSelected = 1;
            nameTextLabel.Text = "Bob";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSelected = 2;
            nameTextLabel.Text = "Al";
        }
    }
}
