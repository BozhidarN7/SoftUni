using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Axe axe;
    private Dummy dummy;
    private Dummy deadDummy;
    private int experience;
    [SetUp]
    public void SetUp()
    {
        experience = 5;
        axe = new Axe(5, 5);
        dummy = new Dummy(5, experience);
        deadDummy = new Dummy(0, experience);
    }
    [Test]
    public void WhenDummyAttacked_ShouldLoseHealth()
    {
        int dummyHealth = dummy.Health;
        axe.Attack(dummy);

        Assert.That(dummy.Health, Is.EqualTo(dummyHealth - axe.AttackPoints));
    }
    [Test]
    public void WhenDummyIsDead_ShouldThrowException()
    {
        axe.Attack(dummy);
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));

    }
    [Test]
    public void When_Dead_ShouldGiveExperience()
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(experience));
    }
    [Test]
    public void When_DummyIsAlive_ShouldNotGiveExperience()
    {
        Assert.That(() => dummy.GiveExperience(), Throws.Exception.With.Message.EqualTo("Target is not dead."));
    }
}
