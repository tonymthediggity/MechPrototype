using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float enemyHealth = 100f;
    public float enemyMeleeDamage = 20;

   
    public float bulletDamage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        



        if(enemyHealth <= 0)
        {
            Die();
        }
		
	}

    void Die()
    {
        Destroy(gameObject);
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            bulletDamage = other.gameObject.GetComponent<Projectile>().damage;
            enemyHealth -= bulletDamage;
        }
    }
}
