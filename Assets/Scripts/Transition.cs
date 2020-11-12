using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Transition : MonoBehaviour {

    public int NextLevel;
    public bool isFinished = false;

    void start()
    {

    }

    public void gameDone()
    {
        isFinished = true;
    }
    // Use this for initialization
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && isFinished)
        {
            SceneManager.LoadScene(NextLevel);
        }
    }


}
