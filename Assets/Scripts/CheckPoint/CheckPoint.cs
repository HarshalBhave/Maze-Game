using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public PlayerHealth playerHealth;
    [SerializeField]private Transform currentCheckPoint;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        if(currentCheckPoint!= null)
        {
            transform.position = currentCheckPoint.transform.position;

        }
        else
        {

        }
        Debug.Log("REspawn");
        playerHealth.dead = false;
        playerHealth.RespwanPlayer();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "CheckPoint")
        {
            currentCheckPoint = other.transform;
            other.GetComponent<Collider>().enabled = false;
        }
    }
}
