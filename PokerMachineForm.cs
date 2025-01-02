namespace PokerMachine
{
    public partial class PokerMachineForm : Form
    {
        private int balance = 100;
        private int currentBet = 10;

        private bool[] holdFlags = new bool[5];
        private List<Card> currentHand;
        private Deck deck;


        private bool isFirstTurn = true;

        private readonly Dictionary<string, int> paytable = new Dictionary<string, int>
        {
            { "Royal Flush", 250 },
            { "Straight Flush", 50 },
            { "Four of a Kind", 25 },
            { "Full House", 9 },
            { "Flush", 6 },
            { "Straight", 4 },
            { "Three of a Kind", 3 },
            { "Two Pair", 2 },
            { "Jacks or Better", 1 }
        };



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
            if (isFirstTurn)
            {
                // First Turn: Deal cards
                balance -= currentBet;
                lblBalance.Text = $"Balance: ${balance}";

                deck = new Deck();
                deck.Shuffle();
                currentHand = DealCards(deck);
                DisplayHand(currentHand);

                isFirstTurn = false;
                btnDeal.Text = "Draw";
            }
            else
            {
                // Second Turn: Replace unheld cards
                for (int i = 0; i < currentHand.Count; i++)
                {
                    if (!holdFlags[i])
                    {
                        currentHand[i] = deck.Draw();
                    }
                }
                DisplayHand(currentHand);

                // Evaluate the hand and calculate the payout
                string result = EvaluateHand(currentHand);
                lblResult.Text = result;

                int payout = CalculatePayout(result, currentBet);
                balance += payout;
                lblBalance.Text = $"Balance: ${balance}";

                // Reset for the next round
                isFirstTurn = true;
                btnDeal.Text = "Deal";
                Array.Fill(holdFlags, false);
                ResetHoldButtons();
            }
        }





        private string EvaluateHand(List<Card> hand)
        {
            // Example logic to determine hand type
            if (IsRoyalFlush(hand)) return "Royal Flush";
            if (IsStraightFlush(hand)) return "Straight Flush";
            if (IsFourOfAKind(hand)) return "Four of a Kind";
            if (IsFullHouse(hand)) return "Full House";
            if (IsFlush(hand)) return "Flush";
            if (IsStraight(hand)) return "Straight";
            if (IsThreeOfAKind(hand)) return "Three of a Kind";
            if (IsTwoPair(hand)) return "Two Pair";
            if (IsJacksOrBetter(hand)) return "Jacks or Better";

            return "No Winning Hand";
        }

        private int CalculatePayout(string handType, int betAmount)
        {
            if (paytable.ContainsKey(handType))
            {
                return paytable[handType] * betAmount;
            }
            return 0; // No payout for losing hands
        }



        private void btnHold1_Click(object sender, EventArgs e)
        {
            ToggleHold(0, btnHold1);
        }

        private void btnHold2_Click(object sender, EventArgs e)
        {
            ToggleHold(1, btnHold2);
        }

        private void btnHold3_Click(object sender, EventArgs e)
        {
            ToggleHold(2, btnHold3);
        }

        private void btnHold4_Click(object sender, EventArgs e)
        {
            ToggleHold(3, btnHold4);
        }

        private void btnHold5_Click(object sender, EventArgs e)
        {
            ToggleHold(4, btnHold5);
        }

        private void ToggleHold(int index, Button button)
        {
            if (index < 0 || index >= holdFlags.Length)
            {
                MessageBox.Show("Invalid hold index!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Toggle the hold state
            holdFlags[index] = !holdFlags[index];

            // Update the button appearance
            if (holdFlags[index])
            {
                button.BackColor = Color.LightGreen; // Indicate held state
                button.Text = "Held";
            }
            else
            {
                button.BackColor = SystemColors.Control; // Reset to default
                button.Text = "Hold";
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


        private void ResetHoldButtons()
        {
            UpdateHoldButtonAppearance(btnHold1, false);
            UpdateHoldButtonAppearance(btnHold2, false);
            UpdateHoldButtonAppearance(btnHold3, false);
            UpdateHoldButtonAppearance(btnHold4, false);
            UpdateHoldButtonAppearance(btnHold5, false);
        }

        private void btnPaytable_Click(object sender, EventArgs e)
        {
            string paytableText = "Paytable:\n\n";
            foreach (var entry in paytable)
            {
                paytableText += $"{entry.Key}: {entry.Value}x\n";
            }
            MessageBox.Show(paytableText, "Paytable", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Paytable

        private bool IsRoyalFlush(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand) && hand.Any(c => c.Rank == "ace");
        }

        private bool IsStraightFlush(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }





    }



}
