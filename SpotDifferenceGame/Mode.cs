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
    public partial class Mode : Form
    {
        Button TryingMode;
        Button TimerMode;
        public Mode ()
        {
            InitializeComponent();
            this.Size = new Size(GlobalVaribles.width, GlobalVaribles.hieght); // width , hieght
            PutBacgroundApp();
            intlaizeButtons("Tries", "Timer");
            AddTwoButtons();
            TryingMode.Click += Tryings_Click;
            TimerMode.Click += Timer_Click;

            //InitializeComponent();
        }

        private void Mode_Load(object sender, EventArgs e)
        {

        }
        public void AddTwoButtons()

        {
            int SizeXButton = 300;
            int SizeYButton = 100;
            int spacing = 150;
            // Set common styles
            TimerMode.Font = TryingMode.Font = new Font("Arial", 20, FontStyle.Bold);

            // Add buttons to form
            this.Controls.Add(TimerMode);
            this.Controls.Add(TryingMode);

            // Transparent background
            TryingMode.BackColor = Color.Transparent;
            TimerMode.BackColor = Color.Transparent;
            TryingMode.Size = new Size(SizeXButton, SizeYButton);
            TryingMode.Location = new Point((GlobalVaribles.width / 2) - (SizeXButton / 2), (Height / 2) - (SizeYButton / 2));
            TimerMode.Size = new Size(SizeXButton, SizeYButton);
            TimerMode.Location = new Point((GlobalVaribles.width / 2) - (SizeXButton / 2), (Height / 2) - (SizeYButton / 2) + spacing);
        }
        public void intlaizeButtons(String firstButton, String SecondButton)
        {
            TryingMode = new Button() { Text = firstButton, ForeColor = Color.Black };
            TimerMode = new Button() { Text = SecondButton, ForeColor = Color.Black };
        }
        public void PutBacgroundApp()
        {
            //DisplayBackgroundWithoutClipping();
            this.BackgroundImage = Image.FromFile(GlobalVaribles.BackgroundImagePath); // Set your image path
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void Tryings_Click(object sender, EventArgs e)
        {
            GlobalVaribles.IsTryings = true;
            Difficults difficultsForm = new Difficults();
            difficultsForm.Show();
            this.Hide(); // Hide the current form (optional)
        }
        private void Timer_Click(object sender, EventArgs e)
        {
            GlobalVaribles.IsTimer = true;
            Difficults difficultsForm = new Difficults();
            difficultsForm.Show();
            this.Hide(); // Hide the current form (optional)
        }
    }
}
