using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        // create a random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();

        // these integer variables store the number 
        // for the addition problem
        int addend1;
        int addend2;

        // this int variable keeps track of the 
        // remaining time.
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start the quiz by filling in all of the problems and starting the timer
        /// </summary>
        public void StartTheQuiz()
        {
            // fill in the addition problem. generate 2 random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // convert the two randomly generated numbers
            // into strrings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // sum is the name of the NumericUpDown control.
            // this step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // start the timer
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                int timedone = 30 - timeLeft;
                // if checktheanswer() returns true, then the user
                // got the answer right. stop the timer
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right! it only took you: " + timedone.ToString() + " seconds.", "Congrats!");
                startButton.Enabled = true;
                            
            }
            if(timeLeft > 0)
            {
                // display the new time left
                // by updating the time left label
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // if the user ran out of time, stop the timer, show
                // a messagebox and fill in the answers
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        /// <summary>
        /// check the answer to see if the user got the question right
        /// </summary>
        /// <returns></returns>
        private bool CheckTheAnswer()
        {
            if(addend1 + addend2 == sum.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
