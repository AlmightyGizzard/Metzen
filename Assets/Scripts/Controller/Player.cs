using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    //vars
    [Range(0f, 20f)]
    public float MovementSpeed;
    public int score = 0;


    public GameObject playerObj;

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    public GameObject plyrHldr;
    public GameObject cHair;

    //meths (don't do drugs)

    //temp
    public Vector3 targetPoint;
    public Quaternion targetRotation;
    float hitDist;
    Plane playerPlane;
    public Ray ray;
    void start()
    {

        hitDist = 0.0f;


    }

    private void Update()
    {


        //Camera

        //var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        //var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;


        playerPlane = new Plane(Vector3.up, transform.position);
        ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        if (playerPlane.Raycast(ray, out hitDist))
        {
            targetPoint = ray.GetPoint(hitDist);
            targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 12f * Time.deltaTime);
            
        }

        cHair.transform.position = new Vector3(targetPoint.x, 1.5f, targetPoint.z);

        //Movement

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime, Space.World);
        }




        //gun McGun Guns
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //Respawning
        //cHair.transform.position = new Vector3( transform.position.x, 1.5f, transform.position.z +5f);

    }//end Update()

    void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

    }

    void OnCollisionEnter(Collision col)
    {
        playerObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }


}
