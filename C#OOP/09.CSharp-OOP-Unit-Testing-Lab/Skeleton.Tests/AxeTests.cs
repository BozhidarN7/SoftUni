using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void When_AttackHasHappened_ShouldWeaponLoseDurability()
    {
        Axe axe = new Axe(5, 4);
        int axeDurabilityPoints = axe.DurabilityPoints;
        Dummy dummy = new Dummy(50, 10);
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(axeDurabilityPoints - 1));
    }
    [Test]
    public void When_AxeDurabilityPointsAreZero_ShouldThrowException()
    {
        Axe axe = new Axe(5, 1);
        Dummy dummy = new Dummy(50, 10);
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}