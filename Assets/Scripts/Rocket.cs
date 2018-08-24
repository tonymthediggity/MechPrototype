using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {



    public float radius = 20.0F;
    public float power = 10000.0F;

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

            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }

            explosion.Play();
            Destroy(gameObject, 0.02f);




        }



    }

}
