using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScore : MonoBehaviour
{


 // coin Collection
  //  public int Score;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            FindObjectOfType<GameManager>().Scoring();
            Destroy(other.gameObject);
        }

    }
    //public void Scoring()
    //{
    //    Score++;
    //    scoreText.text = Score.ToString();
    //    Debug.Log("Score");
    //}

}
