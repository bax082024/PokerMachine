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

    }
}
