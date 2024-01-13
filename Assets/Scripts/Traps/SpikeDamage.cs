using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : TrapDamage
{
    public float Damage;

    public override float GetDamage()
    {
        return Damage;
    }

}
