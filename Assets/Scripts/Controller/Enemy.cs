using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    [Range(.1f, 20f)]
    public float lookRadius = 20f;

    [Range(.1f, 20f)]
    public float RunRadius = 5f;

    public float speed;
    Transform target;
    NavMeshAgent agent;
    UI ui;
    //Player plyr;
    public GameObject plyr;

    public float health = 10;

	// Use this for initialization
	void Start () {
        target = plyr.transform;
        agent = GetComponent<NavMeshAgent>();
        ui = GameObject.Find("UIHandler").GetComponent<UI>();

    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);

        if(health <= 0)
        {
            Die();
        }

        if(distance <= lookRadius)
        {
            agent.speed = 20f;
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                //attack and kill target
            }
        }
	}

    public void Die()
    {
        //ui.score += 1;
        ui.setScore();
        print("Enemy " + this.gameObject.name + " has died!");
        Destroy(this.gameObject);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Bullet")
        {   
            
            Destroy(col.gameObject);
            Die();
            Debug.Log(ui.score);

        }
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("enemy wins");
            col.gameObject.SetActive(false);
            plyr.gameObject.SetActive(false);
            ui.Die();

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, RunRadius);
    }
}
