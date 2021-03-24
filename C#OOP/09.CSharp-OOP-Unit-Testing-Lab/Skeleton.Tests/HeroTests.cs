using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void WhenHeroAttackAndTargetDies_ShouldGainExperience()
    {
        ITarget target = new FakeTarget();
        IWeapon weapon = new FakeWeapon();
        Hero hero = new Hero("Test", weapon);
        hero.Attack(target);

        Assert.AreEqual(hero.Experience, target.GiveExperience());
    }
}