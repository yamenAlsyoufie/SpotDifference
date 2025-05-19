using Emgu.CV.Stitching;

namespace SpotDifferenceGame
{
    public partial class Form1 : Form
    {
        Button NewGameButton;
        Button QuitGameButton;
        Label label = new Label();
        System.Timers.Timer timer;
        Form1 form;
        public Form1()
        {
            InitializeComponent();

            intlaizeButtons("New Game" ,"Quit Game");
            PutBacgroundApp();
            this.Size = new Size(GlobalVaribles.width,GlobalVaribles.hieght); // width , hieght
            AddTwoButtons();
            NewGameButton.Click += NewGameButton_Click;
            QuitGameButton.Click += (s, e) => this.Close(); // Optional: quit app
        }


        private void Form1_Load(object sender, EventArgs e)
        {
         //   AddTwoButtons();
        }

      
        public void AddTwoButtons()

        {
            int SizeXButton = (GlobalVaribles.width)/7;
            int SizeYButton = (GlobalVaribles.hieght)/11;
            int spacing = 150;
            // Set common styles
            NewGameButton.Font = QuitGameButton.Font = new Font("Arial",20 , FontStyle.Bold);

            // Add buttons to form
            this.Controls.Add(NewGameButton);
            this.Controls.Add(QuitGameButton);
            this.Controls.Add(label);
            // Transparent background
            NewGameButton.BackColor = Color.Transparent;
            QuitGameButton.BackColor = Color.Transparent;
            NewGameButton.Size = new Size(SizeXButton , SizeYButton);
            NewGameButton.Location = new Point((GlobalVaribles.width / 2) - (SizeXButton / 2), (Height / 2) - (SizeYButton / 2));
            QuitGameButton.Size = new Size(SizeXButton, SizeYButton);
            QuitGameButton.Location = new Point((GlobalVaribles.width/2) - (SizeXButton/2), (Height/2) - (SizeYButton / 2) + spacing);
        }
        public void intlaizeButtons(String firstButton , String SecondButton)
        {
            NewGameButton = new Button() { Text = firstButton, ForeColor = Color.Black };
            QuitGameButton = new Button() { Text = SecondButton, ForeColor = Color.Black };
        }
        public void PutBacgroundApp()
        {
            //DisplayBackgroundWithoutClipping();
            this.BackgroundImage = Image.FromFile(GlobalVaribles.BackgroundImagePath); // Set your image path
            this.BackgroundImageLayout = ImageLayout.Stretch;
         
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Mode modeForm = new Mode();
            modeForm.Show();
            this.Hide(); // Hide the current form (optional)
        }
    }
}
