using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    public int AttackPoints { get;  }
    public int DurabilityPoints { get;  }
    public void Attack(ITarget target);
}

