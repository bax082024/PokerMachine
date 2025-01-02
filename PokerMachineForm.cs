namespace PokerMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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


    }
}
