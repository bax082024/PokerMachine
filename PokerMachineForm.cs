namespace PokerMachine
{
    public partial class Form1 : Form
    {
        private int balance = 100;
        private int currentBet = 10;


        public Form1()
        {
            InitializeComponent();

            lblBalance.Text = $"Balance: ${balance}";
            lblBet.Text = $"Bet: ${currentBet}";
        }

        private Image LoadCardImage(string rank, string suit)
        {
            string imagePath = $"Images/Cards/{rank}_{suit}.png";
            return Image.FromFile(imagePath);
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
            pictureBox1.Image = LoadCardImage(hand[0].Rank, hand[0].Suit);
            pictureBox2.Image = LoadCardImage(hand[1].Rank, hand[1].Suit);
            pictureBox3.Image = LoadCardImage(hand[2].Rank, hand[2].Suit);
            pictureBox4.Image = LoadCardImage(hand[3].Rank, hand[3].Suit);
            pictureBox5.Image = LoadCardImage(hand[4].Rank, hand[4].Suit);
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (balance >= currentBet)
            {
                balance -= currentBet;
                lblBalance.Text = $"Balance: ${balance}";

                // Deal cards
                Deck deck = new Deck();
                deck.Shuffle();
                List<Card> hand = DealCards(deck);
                DisplayHand(hand);
            }
            else
            {
                MessageBox.Show("Not enough balance to place a bet!");
            }
        }

    }
}
