using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories.Models
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            cards = new List<ICard>();
        }
        public int Count => cards.Count;


        public IReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if (Find(card.Name) == null)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            cards.Add(card);
        }

        public ICard Find(string name)
        {
            return cards.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (!cards.Remove(card))
            {
                throw new ArgumentException("Card cannot be null!");
            }
            return true;
        }
    }
}
