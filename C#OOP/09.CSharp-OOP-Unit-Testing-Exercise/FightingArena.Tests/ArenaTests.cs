
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void When_CtorCall_ShouldCreateNewCollection()
        {
            IReadOnlyCollection<Warrior> warrios = new List<Warrior>();
            Assert.That(arena.Warriors, Is.EquivalentTo(warrios));
        }
        [Test]
        public void WhenEnrollCall_ShouldEncreaseCount()
        {
            Warrior warrior = new Warrior("Test", 20, 40);
            int count = arena.Count;
            arena.Enroll(warrior);
            Assert.AreEqual(arena.Count, count + 1);
        }
        [Test]
        public void WhenEnrollFindDuplicateName_ShouldThrowException()
        {
            Warrior attacker = new Warrior("Attacker", 30, 50);
            Warrior defender = new Warrior("Attacker", 20, 40);
            arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(defender));
        }
        [Test]
        public void WhenFightCantFindWarrior_ShouldThrowExeption()
        {
            Warrior attacker = new Warrior("Attacker", 30, 50);
            Warrior defender = new Warrior("Defender", 20, 40);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() => arena
            .Fight("Attacker", "test"));
        }
        [Test]
        public void WhenFight_ShouldDecreaseHP()
        {
            Warrior attacker = new Warrior("Attacker", 30, 50);
            Warrior defender = new Warrior("Defender", 20, 40);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            int attackerHP = attacker.HP;
            int defenderHP = defender.HP;
            arena.Fight("Attacker","Defender");
            Assert.That(attacker.HP == attackerHP - defender.Damage &&
                defender.HP == defenderHP - attacker.Damage);
        }
    }
}
