using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public ParticleSystem explosion;
    public GameObject firePoint;
    public float damage = 20;

  

    private void Awake()
    {

     

        firePoint = GameObject.FindGameObjectWithTag("PlayerFirePoint");


        explosion = GetComponent<ParticleSystem>();
        explosion.Stop();
    }



    private void OnCollisionEnter(Collision other)
    {
      








        if (!other.gameObject.CompareTag("Player"))
        {



            explosion.Play();
            Destroy(gameObject, 0.02f);




        }



    }

}
