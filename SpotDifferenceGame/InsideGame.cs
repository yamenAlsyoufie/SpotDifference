using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.Media;

namespace SpotDifferenceGame
{
    public partial class InsideGame : Form
    {
        Label label = new Label();
        System.Timers.Timer timer;
        private Point? firstClickPoint = null;
        private PictureBox firstClickedBox = null;

        public InsideGame()
        {
            conditions(); //dtermine mode of the game
            LabelDesign(); //LabelDesign Inside the game
            InitializeComponent();
            this.Size = new Size(GlobalVaribles.width, GlobalVaribles.hieght); //resize for the window
            PutBacgroundApp();
            this.Controls.Add(label);
           GlobalVaribles.correctSound = new SoundPlayer(GlobalVaribles.CorrectSoundPath); // Set your correct sound file path
           GlobalVaribles.wrongSound = new SoundPlayer(GlobalVaribles.WrongSoundPath);     // Set your wrong sound file path
            GlobalVaribles.firstPhoto = AddPhoto(GlobalVaribles.FirstPhotoDifference, GlobalVaribles.width / 8, GlobalVaribles.hieght / 5);
            GlobalVaribles.secondPhoto = AddPhoto(GlobalVaribles.SecondPhotoDifference, GlobalVaribles.width / 2, GlobalVaribles.hieght / 5);

            GlobalVaribles.firstPhoto.Click += Photo_Click; //this function use to determine the colors and between them
            GlobalVaribles.secondPhoto.Click += Photo_Click;//this function use to determine the colors and between them

            UpdateLabel();
        }
        //-----------------------------------------------------------------------------------------------
        public void PutBacgroundApp()
        {
            this.BackgroundImage = Image.FromFile(GlobalVaribles.BackgroundImagePath2);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        //----------------------------------------------------------------------------------------------
        public void IntliazeTimer() //intliaz the timer 
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) //count the timer
        {
            Invoke(new Action(() =>
            {
                if (GlobalVaribles.totalSeconds <= 0)
                {
                    timer.Stop();
                    label.Text = "Time: 0:00";

                    if (GlobalVaribles.differencesRemaining > 0)
                    {
                        MessageBox.Show("Time's up! You didn't find all the differences.\nGame Over.");
                    }
                    else
                    {
                        MessageBox.Show("Congratulations! You found all the differences just in time!");
                    }

                    this.Close();
                    return;
                }

                GlobalVaribles.totalSeconds--;

                UpdateLabel();
            }));
        }
        //-------------------------------------------------------------------------------------------------------
        private void LabelDesign() //Label Desing inside the game 
        {
            label.Font = new Font("Arial", 24, FontStyle.Bold);
            label.Size = new Size(GlobalVaribles.LabelXSize, GlobalVaribles.LabelYSize);
            label.BackColor = Color.Transparent;
            label.Location = new Point((GlobalVaribles.width / 2) - (GlobalVaribles.LabelXSize / 2), GlobalVaribles.hieght / 10);
        }

        private void UpdateLabel() // this is use to update the label for timer and tries and number of differences
        {
            if (GlobalVaribles.IsTimer)
            {
                int m = GlobalVaribles.totalSeconds / 60;
                int s = GlobalVaribles.totalSeconds % 60;
                label.Text = $"Time: {m}:{s:D2}  |  Differences Left: {GlobalVaribles.differencesRemaining}";
            }
            else if (GlobalVaribles.IsTryings)
            {
                label.Text = $"Tries: {GlobalVaribles.totalTryings}  |  Differences Left: {GlobalVaribles.differencesRemaining}";
            }
        }

        public PictureBox AddPhoto(string pathPhoto, int locationX, int locationY)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(pathPhoto);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Location = new Point(locationX, locationY);
            pictureBox.Size = new Size(500, 666);
            pictureBox.Cursor = Cursors.Hand;
            pictureBox.BackColor = Color.Transparent;

            this.Controls.Add(pictureBox);

            return pictureBox;
        }

        private void Photo_Click(object sender, EventArgs e) //this function use to determine the colors and between them
        {
            PictureBox clickedBox = sender as PictureBox;
            MouseEventArgs me = e as MouseEventArgs;
            if (clickedBox == null || me == null || clickedBox.Image == null)
                return;

            int imgX = me.X * clickedBox.Image.Width / clickedBox.Width;
            int imgY = me.Y * clickedBox.Image.Height / clickedBox.Height;

            if (firstClickPoint == null)
            {
                firstClickPoint = new Point(imgX, imgY);
                firstClickedBox = clickedBox;
            }
            else
            {
                if (clickedBox == firstClickedBox)
                {
                    MessageBox.Show("You must click both photos to compare.");
                    firstClickPoint = null;
                    firstClickedBox = null;
                    return;
                }

                Point secondClickPoint = new Point(imgX, imgY);

                Bitmap firstImg = (Bitmap)firstClickedBox.Image;
                Bitmap secondImg = (Bitmap)clickedBox.Image;

                Color firstColor = firstImg.GetPixel(firstClickPoint.Value.X, firstClickPoint.Value.Y);
                Color secondColor = secondImg.GetPixel(secondClickPoint.X, secondClickPoint.Y);

                bool isDifferent = IsColorDifferent(firstColor, secondColor);

                GlobalVaribles.totalTryings--;

                if (isDifferent)
                {
                    GlobalVaribles.correctSound.Play();
                    GlobalVaribles.differencesRemaining--;

                    if (GlobalVaribles.differencesRemaining == 0)
                    {
                        UpdateLabel();
                        MessageBox.Show("Congratulations! You found all the differences.");
                        this.Close();
                        return;
                    }
                }
                else
                {
                    GlobalVaribles.wrongSound.Play();
                    // MessageBox.Show("No difference at selected points.");
                }

                if ((GlobalVaribles.totalTryings <= 0&&GlobalVaribles.IsTryings)||(GlobalVaribles.IsTimer && GlobalVaribles.totalSeconds==0))
                {
                    UpdateLabel();
                    MessageBox.Show("No more tries! Game Over.");
                    this.Close();
                    return;
                }

                UpdateLabel();

                firstClickPoint = null;
                firstClickedBox = null;
            }
        }

        private bool IsColorDifferent(Color a, Color b, int tolerance = 25)
        {
            return Math.Abs(a.R - b.R) > tolerance ||
                   Math.Abs(a.G - b.G) > tolerance ||
                   Math.Abs(a.B - b.B) > tolerance;
        }
        //-------------------------------------------------------------------------------------
        private void conditions() //this condtions to determine mode of the game
        {
            if (GlobalVaribles.IsTimer)
            {
                if (GlobalVaribles.IsEasy)
                    GlobalVaribles.totalSeconds = 120;
                else if (GlobalVaribles.IsMedium)
                    GlobalVaribles.totalSeconds = 90;
                else if (GlobalVaribles.IsHard)
                    GlobalVaribles.totalSeconds = 60;
                IntliazeTimer();
            }
            else if (GlobalVaribles.IsTryings)
            {
                if (GlobalVaribles.IsEasy)
                    GlobalVaribles.totalTryings = 10;
                else if (GlobalVaribles.IsMedium)
                    GlobalVaribles.totalTryings = 8;
                else if (GlobalVaribles.IsHard)
                    GlobalVaribles.totalTryings = 5;
            }
        }
    }
}