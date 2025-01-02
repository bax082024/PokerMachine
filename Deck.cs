using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerMachine
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            string[] suits = { "heart", "diamond", "club", "spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "j", "q", "k", "ace" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }


    }
}
