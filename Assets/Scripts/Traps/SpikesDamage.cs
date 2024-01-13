using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDamage : TrapDamage
{
    public float damage;
    public override float GetDamage()
    {
        return damage;
    }
}
