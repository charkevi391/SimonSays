using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        Random randGen = new Random();
        public static int guessValue = 0;
        System.Windows.Media.MediaPlayer backMedia = new System.Windows.Media.MediaPlayer();

        public GameScreen()
        {
            InitializeComponent();
        }

        Color[] ColorArray = new Color[8];
        Button[] ButtonArray = new Button[4];
        SoundPlayer[] SoundArray = new SoundPlayer[5];
        Image[] ImageArray = new Image[8];

        private void GameScreen_Load(object sender, EventArgs e)
        {
            ColorArray[0] = Color.DarkBlue;
            ColorArray[1] = Color.Blue;
            ColorArray[2] = Color.DarkRed;
            ColorArray[3] = Color.Red;
            ColorArray[4] = Color.Goldenrod;
            ColorArray[5] = Color.Yellow;
            ColorArray[6] = Color.ForestGreen;
            ColorArray[7] = Color.YellowGreen;

            ButtonArray[0] = redButton;
            ButtonArray[1] = blueButton;
            ButtonArray[2] = greenButton;
            ButtonArray[3] = yellowButton;

            SoundArray[0] = new SoundPlayer(Properties.Resources.mistake);
            SoundArray[1] = new SoundPlayer(Properties.Resources.blue);
            SoundArray[2] = new SoundPlayer(Properties.Resources.red);
            SoundArray[3] = new SoundPlayer(Properties.Resources.green);
            SoundArray[4] = new SoundPlayer(Properties.Resources.yellow);

            ImageArray[0] = Properties.Resources.redpic;
            ImageArray[1] = Properties.Resources.greenpic;
            ImageArray[2] = Properties.Resources.yelllowpic;
            ImageArray[3] = Properties.Resources.bluepic;
            ImageArray[4] = Properties.Resources.Reddead;
            ImageArray[5] = Properties.Resources.Greendead;
            ImageArray[6] = Properties.Resources.Yellowdead;
            ImageArray[7] = Properties.Resources.Bluedead;

            backMedia.Open(new Uri(Application.StartupPath + "/Resources/amongussong.wav"));
            backMedia.MediaEnded += new EventHandler(backMedia_MediaEnded);
//
            Form1.SimonPattern.Clear();
            Refresh();
            Thread.Sleep(1000);
            backMedia.Play();
            ComputerTurn();
        }
        private void ComputerTurn()
        {

            Form1.SimonPattern.Add(randGen.Next(0, 3));
            for (int i = 0; i < Form1.SimonPattern.Count(); i++)
            {
                if (Form1.SimonPattern[i] == 0)
                {
                    ButtonPressColorSound(7, 3, 2, 6, 5, 1);
                }
                if (Form1.SimonPattern[i] == 1)
                {
                    ButtonPressColorSound(3, 2, 0, 2, 4, 0);
                }
                if (Form1.SimonPattern[i] == 2)
                {
                    ButtonPressColorSound(5, 4, 3, 4, 6, 2);
                }
                if (Form1.SimonPattern[i] == 3)
                {
                    ButtonPressColorSound(1, 1, 1, 0, 7, 3);
                }
                guessValue = 0;
            }
        }
        public void GameOver()
        {
            SoundArray[0].Play();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameOverScreen os = new GameOverScreen();
            f.Controls.Add(os);
        }
        public void ButtonPressColorSound(int color, int sound, int pressed, int color2, int picture1, int picture2)
        {
            SoundArray[sound].Play();
            ButtonArray[pressed].BackColor = ColorArray[color];
            ButtonArray[pressed].BackgroundImage = ImageArray[picture1];
            Refresh();
            Thread.Sleep(500);
            ButtonArray[pressed].BackColor = ColorArray[color2];
            ButtonArray[pressed].BackgroundImage = ImageArray[picture2];
            Refresh();
            Thread.Sleep(500);
        }
        private void backMedia_MediaEnded(object sender, EventArgs e)
        {
            backMedia.Stop();
            backMedia.Play();
        }
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (Form1.SimonPattern[guessValue] == 0)
            {
                ButtonPressColorSound(7, 3, 2, 6, 5, 1);
                guessValue++;
                if (Form1.SimonPattern.Count() == guessValue)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.SimonPattern[guessValue] == 1)
            {
                ButtonPressColorSound(3, 2, 0, 2, 4, 0);
                guessValue++;
                if (Form1.SimonPattern.Count() == guessValue)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.SimonPattern[guessValue] == 2)
            {
                ButtonPressColorSound(5, 4, 3, 4, 6, 2);
                guessValue++;
                if (Form1.SimonPattern.Count() == guessValue)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.SimonPattern[guessValue] == 3)
            {
                ButtonPressColorSound(1, 1, 1, 0, 7, 3);
                guessValue++;
                if (Form1.SimonPattern.Count() == guessValue)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }
    }
}