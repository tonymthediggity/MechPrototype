using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public GameObject firePoint;
    public GameObject bulletPrefab;
    GameObject bulletClone;

    public GameObject rocketPrefab;
    GameObject rocketClone;

    public Image crossHair;

    public Vector3 crossHairPos;

    RaycastHit hit;
    RaycastHit bit;

    public float speed;



    public float distance;

    // Use this for initialization
    void Start()
    {

        hit = new RaycastHit();



    }

    // Update is called once per frame
    void Update()
    {

        crossHairPos = crossHair.transform.position;





        if (Input.GetButtonDown("Fire1"))
        {




            Ray ray = Camera.main.ScreenPointToRay(crossHairPos);
            if (Physics.Raycast(ray, out hit))
            {

                //bulletPrefab = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
                // Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

                bulletClone = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
                bulletClone.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * speed;

                Destroy(bulletClone, 3);


            }



        }

        if (Input.GetButtonDown("Fire2"))
        {



            Debug.Log("ROCKET TIME");

            Ray bay = Camera.main.ScreenPointToRay(crossHairPos);
            if (Physics.Raycast(bay, out bit))
            {



                //bulletPrefab = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
                // Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

                rocketClone = Instantiate(rocketPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
                rocketClone.GetComponent<Rigidbody>().velocity = (bit.point - transform.position).normalized * speed;

                Destroy(rocketClone, 3);







            }




        }

    }
}

