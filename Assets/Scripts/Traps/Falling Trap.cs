using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : TrapDamage
{
    public float wait;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collison has happen");
            DelayDestroy();
            Destroy(gameObject);
        }
    }


    public IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(wait);
        
    }

    

}
