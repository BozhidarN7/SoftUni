using System;
using System.Collections.Generic;
using System.Text;

public interface ITarget
{
    public int Health { get; }
    public int GiveExperience();
    public bool IsDead();
    public void TakeAttack(int attackPoints);
}

