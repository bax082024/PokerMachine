using System.Drawing.Drawing2D;

namespace PokerMachine
{
    public partial class PokerMachineForm : Form
    {
        private int balance = 100;
        private int currentBet = 1;

        private bool[] holdFlags = new bool[5];
        private List<Card> currentHand = new List<Card>();
        private Deck deck = new Deck();


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
            lblResult.Text = "Good luck!";

            if (isFirstTurn)
            {
                // Check if the player has enough credits to place the bet
                if (currentBet > balance)
                {
                    MessageBox.Show("You don't have enough credits to place this bet.", "Insufficient Credits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Prevent further execution if the bet is too high
                }

                // First Turn: Deduct credits and deal cards
                balance -= currentBet;
                lblBalance.Text = $"Balance: ${balance}";

                deck = new Deck();
                deck.Shuffle();
                currentHand = DealCards(deck);
                DisplayHand(currentHand);

                isFirstTurn = false;
                btnDeal.Text = "Draw"; // Change button text to "Draw"
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
                int payout = CalculatePayout(result, currentBet);

                // Update lblResult to display hand type and payout
                if (payout > 0)
                {
                    lblResult.Text = $"{result}! You won ${payout}.";
                }
                else
                {
                    lblResult.Text = $"{result}. Better luck next time!";
                }

                // Update balance with winnings
                balance += payout;
                lblBalance.Text = $"Balance: ${balance}";

                // Reset for the next round
                isFirstTurn = true;
                btnDeal.Text = "Deal"; // Reset button text
                Array.Fill(holdFlags, false); // Reset hold flags
                ResetHoldButtons(); // Reset button appearance
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
                button.BackColor = Color.DarkGray;
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

        private bool IsFourOfAKind(List<Card> hand)
        {
            return hand.GroupBy(c => c.Rank).Any(g => g.Count() == 4);
        }

        private bool IsFullHouse(List<Card> hand)
        {
            var groups = hand.GroupBy(c => c.Rank).ToList();
            return groups.Count == 2 && (groups[0].Count() == 3 || groups[1].Count() == 3);
        }

        private bool IsFlush(List<Card> hand)
        {
            return hand.All(c => c.Suit == hand[0].Suit);
        }

        private bool IsStraight(List<Card> hand)
        {
            var ranks = hand.Select(c => GetRankValue(c.Rank)).OrderBy(v => v).ToList();
            for (int i = 1; i < ranks.Count; i++)
            {
                if (ranks[i] != ranks[i - 1] + 1)
                {
                    return false;
                }
            }
            return true;
        }

        private int GetRankValue(string rank)
        {
            return rank switch
            {
                "2" => 2,
                "3" => 3,
                "4" => 4,
                "5" => 5,
                "6" => 6,
                "7" => 7,
                "8" => 8,
                "9" => 9,
                "10" => 10,
                "j" => 11,
                "q" => 12,
                "k" => 13,
                "ace" => 14,
                _ => 0
            };
        }

        private bool IsThreeOfAKind(List<Card> hand)
        {
            return hand.GroupBy(c => c.Rank).Any(g => g.Count() == 3);
        }

        private bool IsTwoPair(List<Card> hand)
        {
            return hand.GroupBy(c => c.Rank).Count(g => g.Count() == 2) == 2;
        }

        private bool IsJacksOrBetter(List<Card> hand)
        {
            var highCards = new HashSet<string> { "j", "q", "k", "ace" };
            return hand.GroupBy(c => c.Rank).Any(g => g.Count() == 2 && highCards.Contains(g.Key));
        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
        //        this.ClientRectangle,
        //        Color.Gray,  // Top color
        //        Color.DimGray,        // Bottom color
        //        LinearGradientMode.Vertical))
        //    {
        //        e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
        //    }
        //}

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            currentBet = (int)numericUpDownBet.Value;
            lblBet.Text = $"Bet: ${currentBet}";
        }

        private void PopulatePaytable()
        {
            // Add headers
            paytableLayout.Controls.Add(new Label { Text = "Hand Type", AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) }, 0, 0);
            paytableLayout.Controls.Add(new Label { Text = "Payout", AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) }, 1, 0);

            // Add rows for each paytable entry
            int rowIndex = 1; // Start after the header row
            foreach (var entry in paytable)
            {
                // Add hand type
                paytableLayout.Controls.Add(new Label { Text = entry.Key, AutoSize = true, Font = new Font("Arial", 9) }, 0, rowIndex);

                // Add payout
                paytableLayout.Controls.Add(new Label { Text = entry.Value.ToString(), AutoSize = true, Font = new Font("Arial", 9) }, 1, rowIndex);

                rowIndex++;
            }
        }



    }



}
