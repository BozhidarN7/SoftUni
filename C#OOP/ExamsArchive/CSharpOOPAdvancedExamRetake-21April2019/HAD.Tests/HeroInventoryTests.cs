

using HAD.Contracts;
using HAD.Entities.Items;
using HAD.Entities.Miscellaneous;
using Moq;
using NUnit.Framework;

namespace HAD.Tests
{
    [TestFixture]
    public class HeroInventoryTests
    {
        Mock<IInventory> inventory;
        [SetUp]
        public void Setup()
        {
            inventory = new Mock<IInventory>();
        }

        [Test]
        public void When_TotalStrengthBonusCall_ShouldReturnHeroStrengthPlusAllItemsBonusStrength()
        {
            int strength = 5;

            Mock<IHero> hero = new Mock<IHero>();
            hero.Setup(x => x.Strength).Returns(strength);

            Mock<IItem> item = new Mock<IItem>();
            item.Setup(x => x.StrengthBonus).Returns(strength);

            inventory.Setup(x => x.TotalStrengthBonus).Returns(hero.Object.Strength + item.Object.StrengthBonus);
            Assert.AreEqual(inventory.Object.TotalStrengthBonus, strength + strength);
        }
        [Test]
        public void When_TotalAgilityBonusCall_ShouldReturnHeroAgilityhPlusAllItemsBonusAgility()
        {
            int agility = 4;

            Mock<IHero> hero = new Mock<IHero>();
            hero.Setup(x => x.Agility).Returns(agility);

            Mock<IItem> item = new Mock<IItem>();
            item.Setup(x => x.AgilityBonus).Returns(agility);

            inventory.Setup(x => x.TotalAgilityBonus).Returns(hero.Object.Agility + item.Object.AgilityBonus);
            Assert.AreEqual(inventory.Object.TotalAgilityBonus, agility + agility);
        }
        [Test]
        public void When_TotalIntelligenceBonusCall_ShouldReturnHeroIntelligencePlusAllItemsBonusIntelligence()
        {
            int intelligence = 3;

            Mock<IHero> hero = new Mock<IHero>();
            hero.Setup(x => x.Intelligence).Returns(intelligence);

            Mock<IItem> item = new Mock<IItem>();
            item.Setup(x => x.IntelligenceBonus).Returns(intelligence);

            inventory.Setup(x => x.TotalIntelligenceBonus).Returns(hero.Object.Intelligence + item.Object.IntelligenceBonus);
            Assert.AreEqual(inventory.Object.TotalIntelligenceBonus, intelligence + intelligence);
        }
        [Test]
        public void When_TotalHitPointsBonusCall_ShouldReturnHeroHitPointsPlusAllItemsBonusHitPoints()
        {
            int hitPoints = 6;

            Mock<IHero> hero = new Mock<IHero>();
            hero.Setup(x => x.HitPoints).Returns(hitPoints);

            Mock<IItem> item = new Mock<IItem>();
            item.Setup(x => x.HitPointsBonus).Returns(hitPoints);

            inventory.Setup(x => x.TotalHitPointsBonus).Returns(hero.Object.HitPoints + item.Object.HitPointsBonus);
            Assert.AreEqual(inventory.Object.TotalHitPointsBonus, hitPoints + hitPoints);
        }
        [Test]
        public void WhenTotalDamageBonusCall_ShouldReturnHeroDamageBonusPlusItemsBonusDamage()
        {
            int damage = 10;
            Mock<IHero> hero = new Mock<IHero>();
            hero.Setup(x => x.Damage).Returns(damage);

            Mock<IItem> item = new Mock<IItem>();
            item.Setup(x => x.DamageBonus).Returns(damage);

            inventory.Setup(x => x.TotalDamageBonus).Returns(hero.Object.Damage + item.Object.DamageBonus);
            Assert.AreEqual(inventory.Object.TotalDamageBonus, damage + damage);
        }

        [Test]
        public void WhenCommonItemsCall_ShouldReturnAllCommonItems()
        {
            IInventory inv = new HeroInventory();
            inv.AddCommonItem(new CommonItem("Item1", 1, 2, 4, 4, 5));
            inv.AddCommonItem(new CommonItem("Item2", 5, 4, 3, 2, 1));

            Assert.That(inv.CommonItems.Count, Is.EqualTo(2));
        }
        [Test]
        public void WhenAddRecipeItemCall_ShouldCombineCommonItemsInRecipeItem()
        {
            IInventory inv = new HeroInventory();
            inv.AddCommonItem(new CommonItem("Orb", 1, 2, 4, 4, 5));
            inv.AddCommonItem(new CommonItem("Staff", 5, 4, 3, 2, 1));
            inv.AddRecipeItem(new RecipeItem("Ring", 10, 10, 10, 10, 10, "Orb", "Staff"));

            Assert.That(inv.CommonItems.Count, Is.EqualTo(1));
        }

    }
}