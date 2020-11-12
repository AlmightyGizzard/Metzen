using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerScript : MonoBehaviour
{
    [Range(0f, 20f)]
    public float detectRadius;
    public GameObject enemy;
    public GameObject DetectPoint;
    public GameObject SpawnPoint;
    Transform target;
    private bool hasSpawned = false; 


    // Use this for initialization
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            Instantiate(enemy.transform, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }

        if (Vector3.Distance(target.position, DetectPoint.transform.position) <= detectRadius)
        {
            Debug.Log("in the circle");
            if (!hasSpawned)
            {
                zergRush();
                hasSpawned = true; 
            }             
        }
    }

    void zergRush()
    {
        Debug.Log("zergRUSH");
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy.transform, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(DetectPoint.transform.position, detectRadius);
    }
}
