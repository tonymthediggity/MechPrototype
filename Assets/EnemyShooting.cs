using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject target;

    public Transform playerPos;
    public Transform enemyPos;
    public float distanceToTarget;


    public BreadcrumbAi.Ai aiScript;
    public bool canShoot = false;

    public GameObject firePoint;
    public GameObject bulletPrefab;
    GameObject bulletClone;
    public float speed;
    
    public float coolDown;
    public float coolDownResetTimer;
    public bool hasShot = false;

    // Use this for initialization
    void Start () {


		
	}

    private void Awake()
    {
        aiScript = GetComponent<BreadcrumbAi.Ai>();
        target = GameObject.FindGameObjectWithTag("Player");
        
        ;
    }

    // Update is called once per frame
    void Update () {

       

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        enemyPos = transform;

        distanceToTarget = Vector3.Distance(transform.position, playerPos.position);

        

        if(distanceToTarget <= 20)
        {
            if (aiScript._HasVision == true && coolDown >= 0.5f)
            {
                
                Shoot();
            }

               
        }

        if (distanceToTarget >= 21 ||aiScript._HasVision == false)
        {
            
        }

        if (hasShot)
        {
            coolDown = coolDown - Time.deltaTime;
        }

        if (coolDown <= 0)
        {
            hasShot = false;
            coolDown = 0.5f;
        }


    }

    void Shoot()
    {

        hasShot = true;
        
        bulletClone = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
        // bulletClone.GetComponent<Rigidbody>().velocity = transform.forward.normalized * speed;

        Vector3 playerPosition = (target.transform.position - firePoint.transform.position).normalized;

        bulletClone.GetComponent<Rigidbody>().AddForce(playerPosition * speed);

        Destroy(bulletClone, 3);

    }
}
