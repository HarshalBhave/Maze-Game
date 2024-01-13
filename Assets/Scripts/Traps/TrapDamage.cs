using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{

    // This Script Giving Damage to player
    //public Player player;

    //   public bool triggerTrap;
    //  public bool activeTrap;
    //  public float dealyTime;
    private float damage;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            other.GetComponent<PlayerHealth>().TakeDamage(GetDamage());
            //        StartCoroutine(DelayDamage());

            //    }
            //    if (activeTrap)
            //    {
            //        if (player != null)
            //        {
            //            player.knockbackBool = true;
            //            player.Knockback(transform);

            //        }
            //    if (!triggerTrap)
            //    {


            //  }
        } 
    }

    public virtual float GetDamage()
    {
        return damage;
    }


    //}



    //private IEnumerator DelayDamage()
    //{
    //    triggerTrap = true;
    //    yield return new WaitForSeconds(dealyTime);
    //    activeTrap = true;
    //    yield return new WaitForSeconds(dealyTime);
    //    triggerTrap = false;
    //    activeTrap = false;
   // }
}

