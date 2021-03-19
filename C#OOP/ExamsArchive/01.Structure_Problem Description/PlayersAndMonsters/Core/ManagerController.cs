namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Cards.Models;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories.Models;
    using System.Linq;
    using PlayersAndMonsters.Models.BattleFields.Models;
    using PlayersAndMonsters.Core.Factories.Models;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerFactory playerFactory;
        private readonly ICardFactory cardFactory;
        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;
        public ManagerController()
        {
            playerFactory = new PlayerFactory();
            cardFactory = new CardFactory();
            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
        }
        public string AddCard(string type, string name)
        {
            ICard card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);
            playerRepository.Add(player);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Find(username);
            ICard card = cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = playerRepository.Find(attackUser);
            IPlayer enemy = playerRepository.Find(enemyUser);
            IBattleField battleField = new BattleField();
            battleField.Fight(attacker, enemy);
            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach (IPlayer player in playerRepository.Players)
            {
                result.AppendLine(player.ToString());
                foreach (ICard card in player.CardRepository.Cards)
                {
                    result.AppendLine(card.ToString());
                }
                result.AppendLine(ConstantMessages.DefaultReportSeparator);
            }
            return result.ToString().TrimEnd();
        }
    }
}
