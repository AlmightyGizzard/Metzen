using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{


    public Rigidbody rb;
    

    public float speed;
    public bool debug;
    private float currentDistance;

    private GameObject triggeringEnemy;

    [Range(.1f, 40f)]
    public float maxDistance;
    [Range(.1f, 3f)]
    public float damage;
    
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        currentDistance += 1 * Time.deltaTime;

        if (currentDistance >= maxDistance)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Wall")
        {
            if (debug == true)
            {
                Debug.Log("wall");
            }
            
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
            

        }
    }
}
