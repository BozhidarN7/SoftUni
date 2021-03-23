
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, 5, 30)]
        [TestCase("    ", 5, 40)]
        [TestCase("Test", -5, 40)]
        [TestCase("Test", 5, -40)]
        public void When_CtorIsCallWithInvalidData_ShouldThrowExceptin(
           string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(
                name, damage, hp));
        }
        [Test]
        public void When_CtorInvolve_ShoultCreatewarrior()
        {
            string name = "Test";
            int damage = 5;
            int hp = 40;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.That(warrior.Name == name && warrior.Damage == damage &&
                warrior.HP == hp);
        }
        [Test]
        public void When_AttackCallWithHPLessThanMinHP_ShouldThrowException()
        {
            Warrior attacker = new Warrior("Attacker", 5, 40);
            Warrior victim = new Warrior("Victim", 5, 20);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(victim));
        }
        [Test]
        public void When_AttackCallWithObjectWithHealthLessThanMinHealth_ShuoldThrowException()
        {
            Warrior attacker = new Warrior("Attacker", 5, 20);
            Warrior victim = new Warrior("Victim", 5, 40);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(victim));
        }
        [Test]
        public void When_AttackAttackerHPLessThanAttackedDamage_ShouldThrowException()
        {
            Warrior attacker = new Warrior("Attacker", 5, 40);
            Warrior victim = new Warrior("Victim", 50, 40);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(victim));
        }
        [Test]
        public void WhenAttackCall_ShouldDecreaseAttackedHP()
        {
            Warrior attacker = new Warrior("Attacker", 5, 40);
            Warrior victim = new Warrior("Victim", 5, 40);
            int victimHp = victim.HP;

            attacker.Attack(victim);
            Assert.AreEqual(victim.HP, victimHp - attacker.Damage);
        }
        public void WhenAttackCall_ShouldDecreaseAttackerHP()
        {
            Warrior attacker = new Warrior("Attacker", 5, 40);
            Warrior victim = new Warrior("Victim", 5, 40);
            int attckerHp = attacker.HP;

            attacker.Attack(victim);
            Assert.AreEqual(attacker.HP, attacker.HP - victim.Damage);
        }
        [Test]
        public void WhenAttackCallHpBecomeNegative_ShouldBeSetToZero()
        {
            Warrior attacker = new Warrior("Attacker", 50, 40);
            Warrior victim = new Warrior("Victim", 5, 40);
            attacker.Attack(victim);
            Assert.AreEqual(victim.HP, 0);
        }
    }
}