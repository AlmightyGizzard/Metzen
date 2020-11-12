using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UI : MonoBehaviour {

    public GameObject plyr;
    public GameObject plyrHldr;
    public int score = 0;
    public int scoreTarget;

    public Text scoreText;
    public Text winText;
    public Text deathText;
    public Text restartText;
    public bool isDead = false;

    public Transition trans;
    public int CurrentScene;
    public GameObject NextLevel;
    public static int L1_Score = 0;

    void start()
    {
        setScore();
        winText.text = "";
        deathText.text = "";
        restartText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("respawn");
            SceneManager.LoadScene(CurrentScene);
        }
    }

   
    public void setScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (score == scoreTarget)
        {
            if(CurrentScene == 3)
            {
                winText.text = "YOU WIN";
            }
            else
            {
                winText.text = "Continue!";
            }
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                L1_Score = score;
                Debug.Log(L1_Score);
            }
            trans.gameDone();
        }

    }

    public void Die()
    {
        deathText.text = "You Died!";
        restartText.text = "press space";
        isDead = true;

        plyrHldr.gameObject.SetActive(false);

    }
}
