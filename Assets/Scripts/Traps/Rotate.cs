using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : TrapDamage
{

    // To Rotate spikes bolder
    public float damage;

    //private void OnTriggerEnter(Collider other)
    //{
        
    //    if (player != null)
    //    {
    //        player.knockbackBool = true;
    //        player.Knockback(transform);
            
    //    }
    //}
  


    void Update()
    {
        transform.Rotate(0f, 0f, 2f, Space.Self);
      //  GetOpstical();
    }

    public override float GetDamage()
    {
        return damage;
    }

}
