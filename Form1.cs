using System.Diagnostics;
using System.Drawing.Text;
using PokerWinForms.Backend;

namespace PokerWinForms
{
    public partial class Form1 : Form
    {
        int opponentFunds = 200;
        int playerFunds = 200;
        int opponentBid = 0;
        int playerBid = 0;
        int turnNumber;
        int roundNumber;
        bool opponentCheck;
        bool playerCheck;
        List<Card> playerHand;
        List<Card> opponentHand;
        List<Card> table;

        public int OpponentFunds { get => opponentFunds; set => opponentFunds = value; }
        public int PlayerFunds { get => playerFunds; set => playerFunds = value; }
        public int OpponentBid { get => opponentBid; set => opponentBid = value; }
        public int PlayerBid { get => playerBid; set => playerBid = value; }
        public bool OpponentCheck { get => opponentCheck; set => opponentCheck = value; }
        public bool PlayerCheck { get => playerCheck; set => playerCheck = value; }
        public List<Card> PlayerHand { get => playerHand; set => playerHand = value; }
        public List<Card> OpponentHand { get => opponentHand; set => opponentHand = value; }
        public List<Card> Table { get => table; set => table = value; }
        public int TurnNumber { get => turnNumber; set => turnNumber = value; }
        public int RoundNumber { get => roundNumber; set => roundNumber = value; }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            HideTableCards();
            labelPoker.Hide();
            buttonStart.Hide();
            if (OpponentFunds > 9 & PlayerFunds > 9) Play();
            else labelActionDesc.Text = "Nie mo¿na zagraæ, poniewa¿ jeden z graczy\nnie ma 10 na start.";
        }

        private void Play()
        {
            SetDefaultValues();
            GenerateGameScreen();

            // playing "first round" - with 3 cards on the table and 2 in each hand - 5 cards to analise
            for (int i = 0; i < 3; i++)
                PlayerHand.Add(Table[i]);

            for (int i = 0; i < 3; i++)
                OpponentHand.Add(Table[i]);
        }



        private void GenerateGameScreen()
        {
            labelOutcome.Hide();
            // displaying some game elements:
            labelFundusze.Show();
            labelFunduszePlayer.Show();
            labelStawka.Show();
            labelStawkaPlayer.Show();
            labelFunduszeInt.Show();
            labelStawkaInt.Show();
            labelFunduszePlayerInt.Show();
            labelStawkaPlayerInt.Show();

            labelActionDesc.Text = "";
            labelAction.Show();
            labelActionDesc.Show();

            labelStawkaInt.Text = OpponentBid.ToString();
            labelFunduszeInt.Text = OpponentFunds.ToString();
            labelFunduszePlayerInt.Text = PlayerFunds.ToString();
            labelStawkaPlayerInt.Text = PlayerBid.ToString();

            buttonPodbij.Show();
            buttonSprawdz.Show();
            buttonZrezygnuj.Show();
            textPodbijValue.Show();

            Dealer.ShuffleDeck();

            // Adding cards to player's and opponent's hands
            for (int i = 0; i < 2; i++)
                PlayerHand.Add(Deck.CurrentCardLayout[i]);


            for (int i = 2; i < 4; i++)
                OpponentHand.Add(Deck.CurrentCardLayout[i]);

            // Adding cards to table
            for (int i = 4; i < 9; i++)
                Table.Add(Deck.CurrentCardLayout[i]);

            // adding images to cards
            try
            {
                picPlaCard1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(PlayerHand[0].Path);
                picPlaCard2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(PlayerHand[1].Path);
                picOppCard1.Image = Properties.Resources.card_back;
                picOppCard2.Image = Properties.Resources.card_back;
                picTabCard1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Table[0].Path);
                picTabCard2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Table[1].Path);
                picTabCard3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Table[2].Path);
                picTabCard4.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Table[3].Path);
                picTabCard5.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Table[4].Path);
            }
            catch (Exception ex)
            {
                throw new ImageNotFoundException($"Could not set card images. {ex}");
            }

            // displaing every card but last two on the table - they are unknown for now
            picPlaCard1.Show();
            picPlaCard2.Show();
            picOppCard1.Show();
            picOppCard2.Show();
            picTabCard1.Show();
            picTabCard2.Show();
            picTabCard3.Show();
            picTabCard4.Hide();
            picTabCard5.Hide();
        }

        private void SetDefaultValues()
        {
            PlayerBid += 10;
            OpponentBid += 10;
            PlayerFunds -= 10;
            OpponentFunds -= 10;
            TurnNumber = 0;
            RoundNumber = 1;
            OpponentCheck = false;
            PlayerCheck = false;
            PlayerHand = new List<Card>();
            OpponentHand = new List<Card>();
            Table = new List<Card>();
        }

        private void buttonZrezygnuj_Click(object sender, EventArgs e)
        {
            ShowDefeatScreen();
        }



        private void buttonSprawdz_Click(object sender, EventArgs e)
        {
            PlayerCheck = true;
            OpponentsTurn();
        }

        private void buttonPodbij_Click(object sender, EventArgs e)
        {
            PlayerCheck = false;
            bool wasSuccesful = int.TryParse(textPodbijValue.Text, out int bid);

            if (!wasSuccesful) labelActionDesc.Text = "Podana wartoœæ nie jest liczb¹ ca³kowit¹.";
            else if (PlayerFunds < bid) labelActionDesc.Text = "Za niskie fundusze.";
            else if (bid <= 0) labelActionDesc.Text = "Podana wartoœæ nie jest liczb¹ dodatni¹.";
            else if (bid > OpponentBid - PlayerBid + OpponentFunds) labelActionDesc.Text = "Wartoœæ jest za du¿a dla twojego rywala.";
            else if (bid + PlayerBid < OpponentBid) labelActionDesc.Text = "Musisz podbiæ o wiêcej, aby dorównaæ\nrywalowi.";
            else
            {
                PlayerBid += bid;
                PlayerFunds -= bid;
                UpdateMoneyLabels();
                OpponentsTurn();
            }
        }

        private void UpdateMoneyLabels()
        {
            labelStawkaInt.Text = OpponentBid.ToString();
            labelFunduszeInt.Text = OpponentFunds.ToString();
            labelFunduszePlayerInt.Text = PlayerFunds.ToString();
            labelStawkaPlayerInt.Text = PlayerBid.ToString();
        }



        private void OpponentsTurn()
        {
            TurnNumber++;
            OpponentCheck = false;
            HidePlayerControls();
            if (OpponentCheck && PlayerCheck) NextRound();
            else if (PlayerBid > OpponentBid) OpponentDecidesNoCheck();  // opponent cannot check if their bid is smaller than player's bid
            else if (TurnNumber > 3) OpponentChecks();  // We dont want opponent to bid too much
            else OpponentDecides();

        }

        private void OpponentDecides()
        {
            MLModel.ModelOutput result = HandEvaluation(OpponentHand);
            switch (result.PredictedLabel)
            {
                case -1: // opponent resigns
                    labelActionDesc.Text = "Przeciwik rezygnuje.";
                    ShowWinScreen();
                    return;
                case 0: // opponent checks
                    OpponentChecks();
                    return;
                case 1:  //opponent bids if the bid is big enough and if they have funds
                    int bid = (int)Math.Round((10 - 2 * TurnNumber) * result.Score.Max()) + 10;
                    if (bid < 12) OpponentChecks();
                    else if (bid > OpponentFunds) OpponentChecks();
                    else if (bid > PlayerFunds)
                    {
                        if (PlayerFunds == 0) OpponentChecks();
                        else
                        {
                            int maximalBid = PlayerFunds;
                            OpponentBids(maximalBid);
                        }
                    }
                    else OpponentBids(bid);
                    return;
                default:
                    OpponentChecks();
                    return;
            }
        }


        private void OpponentDecidesNoCheck()
        {
            int minimalBid = PlayerBid - OpponentBid;
            MLModel.ModelOutput result = HandEvaluation(OpponentHand);
            switch (result.PredictedLabel)
            {
                case -1: // opponent resigns
                    labelActionDesc.Text = "Przeciwik rezygnuje.";
                    ShowWinScreen();
                    return;
                case 0: // opponent would check, but they can't
                    if (result.Score.Max() > 0.6) // opponent resigns, because probability od loss is high
                    {
                        labelActionDesc.Text = "Przeciwik rezygnuje.";
                        ShowWinScreen();
                    }
                    else OpponentBids(minimalBid); 
                    return;
                case 1:  //opponent bids if the bid is big enough and if they have funds
                    int bid = (int)Math.Round((10 - 2 * TurnNumber) * result.Score.Max()) + 10;
                    if (bid - minimalBid > PlayerFunds) OpponentBids(minimalBid);  // opponent bid cannot be too big
                    else if (minimalBid > bid) OpponentBids(minimalBid);
                    else if (bid <= OpponentFunds) OpponentBids(bid);
                    else OpponentBids(minimalBid);
                    return;
            }
        }

        private void OpponentBids(int bid)
        {
            OpponentFunds -= bid;
            OpponentBid += bid;
            labelActionDesc.Text = "Przeciwnik podbija o " + bid.ToString() + ".";
            UpdateMoneyLabels();
            PlayersTurn();
        }

        private void OpponentChecks()
        {
            labelActionDesc.Text = "Przeciwnik sprawdza.";
            OpponentCheck = true;
            PlayersTurn();
        }



        private void HidePlayerControls()
        {
            buttonPodbij.Hide();
            buttonSprawdz.Hide();
            buttonZrezygnuj.Hide();
            textPodbijValue.Hide();
        }

        private void ShowPlayerControls()
        {
            buttonPodbij.Show();
            buttonZrezygnuj.Show();
            textPodbijValue.Show();
            if (PlayerBid >= OpponentBid) buttonSprawdz.Show();  // player can't check if opponent's bid is bigger than theirs
        }

        private void NextRound()
        {
            RoundNumber++;
            if (RoundNumber > 3)
            {
                ComputeGameResults();
                return;
            }
            else if (RoundNumber == 2)
            {
                picTabCard4.Show();
                PlayerHand.Add(Table[3]);
                OpponentHand.Add(Table[3]);
            }
            else if (RoundNumber == 3)
            {
                picTabCard5.Show();
                PlayerHand.Add(Table[4]);
                OpponentHand.Add(Table[4]);
            }
            if (PlayerFunds == 0 || OpponentFunds == 0) NoFundsLeftEnding();
            else
            {
                PlayerCheck = false;
                OpponentCheck = false;
                TurnNumber = 0;
                ShowPlayerControls();  // Player can play now
            }
        }

        private void NoFundsLeftEnding()
        {
            if (RoundNumber == 2) // adding last two cards to the table
            {
                picTabCard5.Show();
                PlayerHand.Add(Table[4]);
                OpponentHand.Add(Table[4]);
            }
            ComputeGameResults();
            labelActionDesc.Text = "Wczeœniejsze zakoñczenie gry z powodu\nbraku funduszy";
            return;
        }
        private void ComputeGameResults()
        {
            Outcome playerScore = Dealer.nthEvaluateInit(PlayerHand);
            Outcome opponentScore = Dealer.nthEvaluateInit(OpponentHand);

            int outcome = Dealer.OutcomeComparator(playerScore, opponentScore);

            switch (outcome)
            {
                case 1:
                    ShowWinScreen();
                    break;
                case 0:
                    ShowTieScreen();
                    break;
                case -1:
                    ShowDefeatScreen();
                    break;
            }
        }
        private MLModel.ModelOutput HandEvaluation(List<Card> hand)
        {
            Outcome eval;
            if (hand.Count == 5 || hand.Count == 6 || hand.Count == 7)
                eval = Dealer.nthEvaluateInit(hand);
            else
                return null;

            var sampleData = new MLModel.ModelInput()
            {
                Col0 = (float)Dealer.EvaluateOutputToInt(eval),
                Col1 = (float)eval.HandUtility,
            };
            var result = MLModel.Predict(sampleData);
            return result;
        }

        private void PlayersTurn()
        {
            if (OpponentCheck && PlayerCheck) NextRound();
            else
            {
                PlayerCheck = false;
                ShowPlayerControls();
            }
        }

        private void ShowWinScreen()
        {
            labelOutcome.Text = "Wygrana";
            labelOutcome.Location = new Point(367, 350);
            PlayerFunds += PlayerBid;
            PlayerFunds += OpponentBid;
            ShowEndScreen();
        }

        private void ShowTieScreen()
        {
            labelOutcome.Text = "Remis";
            labelOutcome.Location = new Point(479, 350);
            PlayerFunds += PlayerBid;
            OpponentFunds += OpponentBid;
            ShowEndScreen();
        }

        private void ShowDefeatScreen()
        {
            labelOutcome.Text = "Przegrana";
            labelOutcome.Location = new Point(317, 350);
            OpponentFunds += OpponentBid;
            OpponentFunds += PlayerBid;
            ShowEndScreen();
        }

        private void ShowEndScreen()
        {
            HidePlayerControls();
            //HideTableCards();
            OpponentBid = 0;
            PlayerBid = 0;
            labelOutcome.Show();
            buttonStart.Size = new Size(372, 172);
            buttonStart.Location = new Point(890, 585);
            buttonStart.Text = "Zagraj ponownie";
            buttonStart.Show();
            try
            {
                picOppCard1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(OpponentHand[0].Path);
                picOppCard2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(OpponentHand[1].Path);
            }
            catch (Exception ex) 
            {
                throw new ImageNotFoundException($"Could not set card images. {ex}");
            }
        }

        private void HideTableCards()
        {
            picTabCard1.Hide();
            picTabCard2.Hide();
            picTabCard3.Hide();
            picTabCard4.Hide();
            picTabCard5.Hide();
        }

    }

}

