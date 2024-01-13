using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // Player Health to detect the current player health
    public float currentHealth { get; private set; }
    public float StartingHealth = 3;
    public bool dead;

    private void Awake()
    {
        currentHealth = StartingHealth;
    }



    public void TakeDamage(float Damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - Damage, 0, StartingHealth);

        if(currentHealth <= 0)
        {
            if (!dead)
            {
                //   GetComponent<CheckPoint>().Respawn();
                //     checkPoint.Respawn();
                GetComponent<CharacterController>().enabled = false;
                dead = true;
                GetComponent<CheckPoint>().Respawn();
                Debug.Log("PLayer Respawn");

            }

        } 
        
    }

    public void AddHealth(float IncreaseHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth + IncreaseHealth, 0, StartingHealth);
    }

    public void RespwanPlayer()
    {
        dead = false;

        GetComponent<CharacterController>().enabled = true;
        AddHealth(StartingHealth);
        Debug.Log("Restore Health");
       // dead = false;
    }
    
}
