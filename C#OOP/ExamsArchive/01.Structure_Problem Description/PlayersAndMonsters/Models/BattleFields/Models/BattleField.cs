using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields.Models
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            BoostPlayer(attackPlayer);
            BoostPlayer(enemyPlayer);

            int turn = 0;
            int attackPlayerDamage = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
            int enemyPlayerDamage = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
            while (attackPlayer.Health > 0 && enemyPlayer.Health > 0)
            {
                if (turn == 0)
                {
                    enemyPlayer.TakeDamage(attackPlayerDamage);
                }
                if (turn == 1)
                {
                    attackPlayer.TakeDamage(enemyPlayerDamage);
                }
                turn ^= 1;
            }

        }

        private void BoostPlayer(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;
                foreach (ICard card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            player.Health += player.CardRepository.Cards.Sum(x => x.HealthPoints);
        }
    }
}
