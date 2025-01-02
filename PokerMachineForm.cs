namespace PokerMachine
{
    public partial class PokerMachineForm : Form
    {
        private int balance = 100;
        private int currentBet = 10;

        private bool[] holdFlags = new bool[5];


        public PokerMachineForm()
        {
            InitializeComponent();

            lblBalance.Text = $"Balance: ${balance}";
            lblBet.Text = $"Bet: ${currentBet}";
        }

        private Image LoadCardImage(string rank, string suit, int width, int height)
        {
            // Construct the image path
            string imagePath = $"Images/Cards/{rank}_{suit}.png";

            // Load the original image
            Image originalImage = Image.FromFile(imagePath);

            // Resize the image to the desired dimensions
            return new Bitmap(originalImage, new Size(width, height));
        }


        private List<Card> DealCards(Deck deck)
        {
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                hand.Add(deck.Draw());
            }
            return hand;
        }

        private void DisplayHand(List<Card> hand)
        {
            pictureBox1.Image = LoadCardImage(hand[0].Rank, hand[0].Suit, pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = LoadCardImage(hand[1].Rank, hand[1].Suit, pictureBox2.Width, pictureBox2.Height);
            pictureBox3.Image = LoadCardImage(hand[2].Rank, hand[2].Suit, pictureBox3.Width, pictureBox3.Height);
            pictureBox4.Image = LoadCardImage(hand[3].Rank, hand[3].Suit, pictureBox4.Width, pictureBox4.Height);
            pictureBox5.Image = LoadCardImage(hand[4].Rank, hand[4].Suit, pictureBox5.Width, pictureBox5.Height);
        }


        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (balance >= currentBet)
            {
                // Deduct the current bet from the balance
                balance -= currentBet;
                lblBalance.Text = $"Balance: ${balance}";

                // Create a new deck and shuffle
                Deck deck = new Deck();
                deck.Shuffle();

                // Deal 5 cards
                List<Card> hand = DealCards(deck);

                // Display the dealt cards in the PictureBoxes
                DisplayHand(hand);

                // Evaluate the hand
                string result = EvaluateHand(hand);

                // Display the result on the label
                lblResult.Text = result;
            }
            else
            {
                // Not enough balance
                MessageBox.Show("Not enough balance to place a bet!");
            }
        }


        private string EvaluateHand(List<Card> hand)
        {
            // Simplified example for a pair
            var rankGroups = hand.GroupBy(card => card.Rank);
            if (rankGroups.Any(group => group.Count() == 2))
                return "Pair!";

            return "No Winning Hand!";
        }

        private void btnHold1_Click(object sender, EventArgs e)
        {
            holdFlags[0] = !holdFlags[0];
            UpdateHoldButtonAppearance(btnHold1, holdFlags[0]);
        }

        private void btnHold2_Click(object sender, EventArgs e)
        {
            holdFlags[0] = !holdFlags[0];
            UpdateHoldButtonAppearance(btnHold1, holdFlags[0]);
        }

        private void btnHold3_Click(object sender, EventArgs e)
        {
            holdFlags[0] = !holdFlags[0];
            UpdateHoldButtonAppearance(btnHold1, holdFlags[0]);
        }

        private void btnHold4_Click(object sender, EventArgs e)
        {
            holdFlags[0] = !holdFlags[0];
            UpdateHoldButtonAppearance(btnHold1, holdFlags[0]);
        }

        private void btnHold5_Click(object sender, EventArgs e)
        {
            holdFlags[0] = !holdFlags[0];
            UpdateHoldButtonAppearance(btnHold1, holdFlags[0]);
        }
    }

    private void UpdateHoldButtonAppearance(Button button, bool isHeld)
        {
            if (isHeld)
            {
                button.BackColor = Color.LightGreen; // Highlight if held
                button.Text = "Held";
            }
            else
            {
                button.BackColor = SystemColors.Control; // Reset to default
                button.Text = "Hold";
            }
        }

    }
