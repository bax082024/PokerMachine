using System.Drawing.Drawing2D;
using WMPLib;

namespace PokerMachine
{
    public partial class PokerMachineForm : Form
    {
        private int balance = 100;
        private int currentBet = 1;

        private bool[] holdFlags = new bool[5];
        private List<Card> currentHand = new List<Card>();
        private Deck deck = new Deck();

        private WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();

        private bool isFirstTurn = true;

        private readonly Dictionary<string, int> leftPaytableData = new Dictionary<string, int>
        {
            { "Royal Flush", 250 },
            { "Straight Flush", 50 },
            { "Four of a Kind", 25 },
            { "Full House", 9 },
            { "Flush", 6 }
        };

        private readonly Dictionary<string, int> rightPaytableData = new Dictionary<string, int>
        {
            { "Straight", 4 },
            { "Three of a Kind", 3 },
            { "Two Pair", 2 },
            { "Jacks or Better", 1 }
        };


        public PokerMachineForm()
        {
            InitializeComponent();
            PopulatePaytablePanels();

            lblBalance.Text = $"Balance: ${balance}";
            lblBet.Text = $"Bet: ${currentBet}";
        }

        private Image LoadCardImage(string rank, string suit, int width, int height)
        {
            string imagePath = $"Images/Cards/{rank}_{suit}.png";

            Image originalImage = Image.FromFile(imagePath);

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
            mediaPlayer.URL = "Sounds/deal.mp3";
            mediaPlayer.controls.play();

            lblResult.Text = "Good luck!";

            if (isFirstTurn)
            {
                if (currentBet > balance)
                {
                    MessageBox.Show("You don't have enough credits to place this bet.", "Insufficient Credits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                for (int i = 0; i < currentHand.Count; i++)
                {
                    if (!holdFlags[i])
                    {
                        currentHand[i] = deck.Draw();
                    }
                }
                DisplayHand(currentHand);

                string result = EvaluateHand(currentHand);
                int payout = CalculatePayout(result, currentBet);

                if (payout > 0)
                {
                    mediaPlayer.URL = "Sounds/win.mp3";
                    mediaPlayer.controls.play();
                    lblResult.Text = $"{result}! You won ${payout}.";
                }
                else
                {
                    lblResult.Text = $"{result}. Better luck next time!";
                }

                balance += payout;
                lblBalance.Text = $"Balance: ${balance}";

                isFirstTurn = true;
                btnDeal.Text = "Deal";
                Array.Fill(holdFlags, false);
                ResetHoldButtons();
            }
        }


        private string EvaluateHand(List<Card> hand)
        {
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
            if (leftPaytableData.ContainsKey(handType))
            {
                return leftPaytableData[handType] * betAmount;
            }
            else if (rightPaytableData.ContainsKey(handType))
            {
                return rightPaytableData[handType] * betAmount;
            }
            return 0;
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

            holdFlags[index] = !holdFlags[index];

            if (holdFlags[index])
            {
                button.BackColor = Color.LightGreen;
                button.Text = "Held";
            }
            else
            {
                button.BackColor = SystemColors.Control;
                button.Text = "Hold";
            }
        }



        private void UpdateHoldButtonAppearance(Button button, bool isHeld)
        {
            if (isHeld)
            {
                button.BackColor = Color.LightGreen;
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

            foreach (var entry in leftPaytableData)
            {
                paytableText += $"{entry.Key}: {entry.Value}x\n";
            }

            paytableText += "\n";

            foreach (var entry in rightPaytableData)
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

        private void PopulatePaytablePanels()
        {
            panelLeftPaytable.Controls.Clear();
            panelExtraLeft.Controls.Clear();
            panelRightPaytable.Controls.Clear();
            panelExtraRight.Controls.Clear();

            int row = 0;
            foreach (var entry in leftPaytableData)
            {
                var handTypeLabel = new Label
                {
                    Text = entry.Key,
                    AutoSize = true,
                    ForeColor = Color.Gold,
                    Font = new Font("Arial", 13, FontStyle.Bold),
                    Location = new Point(10, row * 20)
                };
                panelLeftPaytable.Controls.Add(handTypeLabel);

                var payoutLabel = new Label
                {
                    Text = entry.Value.ToString(),
                    AutoSize = true,
                    ForeColor = Color.Gold,
                    Font = new Font("Arial", 13, FontStyle.Bold),
                    Location = new Point(10, row * 20)
                };
                panelExtraLeft.Controls.Add(payoutLabel);

                row++;
            }

            row = 0;
            foreach (var entry in rightPaytableData)
            {
                var handTypeLabel = new Label
                {
                    Text = entry.Key,
                    AutoSize = true,
                    ForeColor = Color.Gold,
                    Font = new Font("Arial", 13, FontStyle.Bold),
                    Location = new Point(10, row * 20)
                };
                panelRightPaytable.Controls.Add(handTypeLabel);

                var payoutLabel = new Label
                {
                    Text = entry.Value.ToString(),
                    AutoSize = true,
                    ForeColor = Color.Gold,
                    Font = new Font("Arial", 13, FontStyle.Bold),
                    Location = new Point(10, row * 20)
                };
                panelExtraRight.Controls.Add(payoutLabel);

                row++;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            balance = 100;

            lblBalance.Text = $"Balance: ${balance}";

            MessageBox.Show("Credits have been reset to $100!", "Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            isFirstTurn = true;
            lblResult.Text = string.Empty;
            Array.Fill(holdFlags, false);
            ResetHoldButtons();
            btnDeal.Text = "Deal";
        }

    }



}
