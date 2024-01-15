using System.Diagnostics;
using System.Drawing.Text;
using Poker;

namespace PokerWinForms
{
    public partial class Form1 : Form
    {
        private string filepath = "C:\\Users\\marle\\source\\repos\\PokerGUI\\images";
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Card c1 = new Card(5);
            this.BackgroundImage = Properties.Resources.background;
            PictureBox pictureBox1 = new PictureBox();
            // getting image of card by its value
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(c1.Path);  
            pictureBox1.Height = pictureBox1.Image.Height;
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Size = new Size(150, 210);
            this.Controls.Add(pictureBox1);*/
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Game()
        {
            // displaying some game elements:
            labelFundusze.Show();
            labelFunduszePlayer.Show();
            labelStawka.Show();
            labelStawkaPlayer.Show();
            labelFunduszeInt.Show();
            labelStawkaInt.Show();
            labelFunduszePlayerInt.Show();
            labelStawkaPlayerInt.Show();

            int fundusze = 190;
            int funduszePlayer = 190;
            int stawka = 10;
            int stawkaPlayer = 10;  

            labelStawkaInt.Text = stawka.ToString();
            labelFunduszeInt.Text = fundusze.ToString();
            labelFunduszePlayerInt.Text = funduszePlayer.ToString();
            labelStawkaPlayerInt.Text = stawkaPlayer.ToString();

            buttonPodbij.Show();
            buttonSprawdz.Show();
            buttonZrezygnuj.Show();
            textPodbijValue.Show();

            Dealer.ShuffleDeck();

            // Adding cards to player's and opponent's hands
            List<Card> playerHand = new List<Card>();
            for (int i = 0; i < 2; i++)
                playerHand.Add(Deck.CurrentCardLayout[i]);

            List<Card> opponentHand = new List<Card>();
            for (int i = 2; i < 4; i++)
                opponentHand.Add(Deck.CurrentCardLayout[i]);
            
            // Adding cards to table
            List<Card> table = new List<Card>();
            for (int i = 4; i < 9; i++)
                table.Add(Deck.CurrentCardLayout[i]);

            // adding images to cards
            picPlaCard1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(playerHand[0].Path);
            picPlaCard2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(playerHand[1].Path);
            picOppCard1.Image = Properties.Resources.card_back;
            picOppCard2.Image = Properties.Resources.card_back;
            picTabCard1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(table[0].Path);
            picTabCard2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(table[1].Path);
            picTabCard3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(table[2].Path);
            picTabCard4.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(table[3].Path);
            picTabCard5.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(table[4].Path);

            // displaing every card but last two on the table - they are unknown for now
            picPlaCard1.Show();
            picPlaCard2.Show();
            picOppCard1.Show();
            picOppCard2.Show();
            picTabCard1.Show();
            picTabCard2.Show();
            picTabCard3.Show(); 

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            labelPoker.Hide();
            buttonStart.Hide();
            Game();
        }

        private MLModel.ModelOutput HandOf5Evaluation(List<Card> hand)
        {
            Outcome eval;
            if (hand.Count == 5 || hand.Count == 6 || hand.Count == 7)
                eval = Dealer.nthEvaluateInit(hand);
            else
                return null;

            var sampleData = new MLModel.ModelInput()
            {
                Col0 = (float)eval.FirstEval,
                Col1 = (float)eval.HandUtility,
            };
            var result = MLModel.Predict(sampleData);
            return result;
        }
    }





}

