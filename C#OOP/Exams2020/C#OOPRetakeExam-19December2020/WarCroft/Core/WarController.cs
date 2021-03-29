using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Characters.Models;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characters;
        private readonly List<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == characterType);
            if (type == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.InvalidCharacterType, characterType));
            }
            Character character = null;
            try
            {

                character = (Character)Activator.CreateInstance(type, name);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

            characters.Add(character);

            return string.Format(Constants.SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == itemName);

            if (type == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.InvalidItem, itemName));
            }
            Item item = (Item)Activator.CreateInstance(type);
            items.Add(item);

            return string.Format(Constants.SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = FindCharacter(characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (items.Count == 0)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ItemPoolEmpty);
            }

            Item item = items.Last();
            try
            {
                character.Bag.AddItem(items.Last());
                items.Remove(item);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }


            return string.Format(Constants.SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = FindCharacter(characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = null;
            try
            {
                item = character.Bag.GetItem(itemName);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                throw ex;
            }

            try
            {
                character.UseItem(item);

            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }

            return string.Format(Constants.SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder result = new StringBuilder();

            foreach (Character character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                result.AppendLine(character.ToString());
            }
            return result.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = FindCharacter(attackerName);
            Character receiver = FindCharacter(receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException(Constants.ExceptionMessages.AttackFail, attackerName);
            }

            try
            {
                ((Warrior)attacker).Attack(receiver);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                throw ex;
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format(Constants.SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints,
                receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                result.AppendLine(string.Format(Constants.SuccessMessages.AttackKillsCharacter, receiverName));
            }
            return result.ToString().TrimEnd();
        }


        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = FindCharacter(healerName);
            Character receiver = FindCharacter(healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healer.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException(Constants.ExceptionMessages.HealerCannotHeal, healerName);
            }

            try
            {
                ((Priest)healer).Heal(receiver);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format(Constants.SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints, healingReceiverName, receiver.Health));
            return result.ToString().TrimEnd();
        }

        private Character FindCharacter(string characterName)
        {
            return characters.FirstOrDefault(x => x.Name == characterName);
        }
    }
}
