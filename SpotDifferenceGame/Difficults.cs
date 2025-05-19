using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotDifferenceGame
{
    public partial class Difficults : Form
    {
        Button EasyButton;
        Button MediumButton;
        Button HardButton;
        public Difficults()
        {
            InitializeComponent();
            this.Size = new Size(GlobalVaribles.width, GlobalVaribles.hieght); // width , hieght
            PutBacgroundApp();
            intlaizeButtons("Easy", "medium","Hard");
            AddThreeButtons();
            EasyButton.Click += Easy_Click;
            MediumButton.Click += Medium_Click;
            HardButton.Click += Hard_Click;
        }

        private void Difficults_Load(object sender, EventArgs e)
        {

        }
        public void AddThreeButtons()

        {
            int SizeXButton = (GlobalVaribles.width) / 7;
            int SizeYButton = (GlobalVaribles.hieght) / 11;
            int spacing = 150;
            // Set common styles
           HardButton.Font= EasyButton.Font = MediumButton.Font = new Font("Arial", 20, FontStyle.Bold);

            // Add buttons to form
            this.Controls.Add(EasyButton);
            this.Controls.Add(MediumButton);
            this.Controls.Add(HardButton);
            // Transparent background
            EasyButton.BackColor = Color.Transparent;
            MediumButton.BackColor = Color.Transparent;
            HardButton.BackColor = Color.Transparent;   
            EasyButton.Size = new Size(SizeXButton, SizeYButton);
            EasyButton.Location = new Point((GlobalVaribles.width / 2) - (SizeXButton / 2), (Height / 2) - (SizeYButton / 2));
            MediumButton.Size = new Size(SizeXButton, SizeYButton);
            MediumButton.Location = new Point((GlobalVaribles.width / 2) - (SizeXButton / 2), (Height / 2) - (SizeYButton / 2) + spacing);
            HardButton.Size = new Size(SizeXButton, SizeYButton);
            HardButton.Location = new Point((GlobalVaribles.width / 2) - (SizeXButton / 2), (Height / 2) - (SizeYButton / 2 )+ spacing*2);
        }
        public void intlaizeButtons(String firstButtonText, String SecondButtonText , String ThirdButtonText)
        {
            EasyButton = new Button() { Text = firstButtonText, ForeColor = Color.Black };
            MediumButton = new Button() { Text = SecondButtonText, ForeColor = Color.Black};
            HardButton = new Button() { Text = ThirdButtonText, ForeColor = Color.Black }; 
        }
        public void PutBacgroundApp()
        {
            //DisplayBackgroundWithoutClipping();
            this.BackgroundImage = Image.FromFile(GlobalVaribles.BackgroundImagePath); // Set your image path
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void Easy_Click(object sender, EventArgs e)
        {
            GlobalVaribles.IsEasy = true;
            InsideGame insideForm = new InsideGame();
            insideForm.Show();
            this.Hide(); // Hide the current form (optional)
        }
        private void Medium_Click(object sender, EventArgs e)
        {
            GlobalVaribles.IsMedium = true;
            InsideGame insideForm = new InsideGame();
            insideForm.Show();
            this.Hide(); // Hide the current form (optional)
        }
        private void Hard_Click(object sender, EventArgs e)
        {
            GlobalVaribles.IsHard = true;
            InsideGame insideForm = new InsideGame();
            insideForm.Show();
            this.Hide(); // Hide the current form (optional)
        }

    }
}
