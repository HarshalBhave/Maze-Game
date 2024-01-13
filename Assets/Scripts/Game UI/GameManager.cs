using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    // To Manage the game Score
    public int Score = 0;

    public Text scoreText;
    //  public int Score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scoring();
            scoreText.text = Score.ToString();
            
        }

    }
    public void Scoring()
    {
        Score++;
        scoreText.text = Score.ToString();
        Debug.Log("Score");
    }

}
