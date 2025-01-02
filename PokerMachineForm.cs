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



    }
}
