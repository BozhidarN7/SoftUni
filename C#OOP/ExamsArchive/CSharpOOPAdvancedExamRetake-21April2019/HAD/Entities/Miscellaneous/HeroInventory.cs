using System.Collections.Generic;
using System.Linq;
using HAD.Contracts;
using HAD.Entities.Items;

namespace HAD.Entities.Miscellaneous
{
    public class HeroInventory : IInventory
    {
        private readonly IList<IItem> commonItems;
        private readonly IList<IRecipe> recipeItems;

        public HeroInventory()
        {
            this.commonItems = new List<IItem>();
            this.recipeItems = new List<IRecipe>();
        }

        public long TotalStrengthBonus => this.commonItems.Sum(i => i.StrengthBonus);

        public long TotalAgilityBonus => this.commonItems.Sum(i => i.AgilityBonus);

        public long TotalIntelligenceBonus => this.commonItems.Sum(i => i.IntelligenceBonus);

        public long TotalHitPointsBonus => this.commonItems.Sum(i => i.HitPointsBonus);

        public long TotalDamageBonus => this.commonItems.Sum(i => i.DamageBonus);

        public IReadOnlyCollection<IItem> CommonItems => this.commonItems.ToList().AsReadOnly();

        public void AddCommonItem(IItem item)
        {
            this.commonItems.Add(item);

            this.CheckRecipes();
        }

        public void AddRecipeItem(IRecipe recipe)
        {
            this.recipeItems.Add(recipe);
            this.CheckRecipes();
        }

        private void CheckRecipes()
        {
            List<IRecipe> recipeItemsToRemove = new List<IRecipe>();
            foreach (var recipe in this.recipeItems)
            {
                var requiredItems = new List<string>(recipe.RequiredItems);

                foreach (var item in this.commonItems)
                {
                    if (requiredItems.Contains(item.Name))
                    {
                        requiredItems.Remove(item.Name);
                    }
                }

                if (requiredItems.Count == 0)
                {
                    this.CombineRecipe(recipe);
                    recipeItemsToRemove.Add(recipe);
                }
            }
            foreach (IRecipe recipeItem in recipeItemsToRemove)
            {
                recipeItems.Remove(recipeItem);
            }
        }

        private void CombineRecipe(IRecipe recipe)
        {
            for (int i = 0; i < recipe.RequiredItems.Count; i++)
            {
                IItem item = commonItems.FirstOrDefault(x => x.Name == recipe.RequiredItems[i]);
                this.commonItems.Remove(item);
            }

            IItem newItem = new CommonItem(recipe.Name,
                recipe.StrengthBonus,
                recipe.AgilityBonus,
                recipe.IntelligenceBonus,
                recipe.HitPointsBonus,
                recipe.DamageBonus);

            this.commonItems.Add(newItem);
        }
    }
}