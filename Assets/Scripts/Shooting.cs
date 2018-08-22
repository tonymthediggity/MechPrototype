using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

    public GameObject firePoint;
    public GameObject bulletPrefab;
    GameObject bulletClone;

    public Image crossHair;

    public Vector3 crossHairPos;

    RaycastHit hit;

    public float speed;

    

    public float distance;

	// Use this for initialization
	void Start () {

        hit = new RaycastHit();



    }
	
	// Update is called once per frame
	void Update () {

        crossHairPos = crossHair.transform.position;

        

        if (Input.GetMouseButtonDown(0))
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


            /* Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             Vector3 myPos = (Vector3)transform.position;
             Vector3 direction = mousePos - myPos;
             direction.Normalize();
             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

             GameObject projectile = (GameObject)Instantiate(bulletPrefab);
             projectile.transform.position = firePoint.transform.position;
             projectile.transform.Rotate(0, angle, 0);
             projectile.GetComponent<Rigidbody>().velocity = direction * speed;




             Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
             position = Camera.main.ScreenToWorldPoint(position);
             Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             Debug.DrawRay(firePoint.transform.position, position, Color.green);
             if (Physics.Raycast(ray, out hit, 100.0f))
             {

             }*/


        }
		
	}
}
