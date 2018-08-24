using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float playerHealth = 100;
    public float enemyDamage;
    public float enemyBulletDamage;
    public Image healthBarFill;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(playerHealth <= 0)
        {
            Die();
        }

        healthBarFill.fillAmount = playerHealth / 100;
		
	}

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {

        
        if (other.gameObject.CompareTag("Enemy"))
        {

            
            enemyDamage = other.gameObject.GetComponent<EnemyHealth>().enemyMeleeDamage;
            playerHealth -= enemyDamage;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {

            Debug.Log("Getting shot by enemy!");
            enemyBulletDamage = other.gameObject.GetComponent<EnemyProjectile>().damage;
            playerHealth -= enemyBulletDamage;

        }
    }


}

