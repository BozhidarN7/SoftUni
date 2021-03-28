using HAD.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAD.Entities.Items
{
    public class RecipeItem : BaseItem, IRecipe
    {
        private readonly List<string> requiredItems;
        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, params string[] requiredItems)
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
            this.requiredItems = requiredItems.ToList();
        }

        public IReadOnlyList<string> RequiredItems => this.requiredItems.AsReadOnly();
    }
}
