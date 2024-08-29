using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int collisionDamage = 20;

    //reference to the healthbar script
    public HealthBar healthBar;
    public GameObject levelFailedCanvas;

    private void Start()
    {
        //set the max health for the healthbar
        healthBar.SetMaxHealth(health);
    }

    //function for player health
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            //call die function, set the level failed canvas to true and stop the game
            Die();
            levelFailedCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    //function to handle enemy death
    public void Die()
    {
        Destroy(gameObject);
    }

    //detect collision with enemy and take damage if colliding with enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the object hit is an enemy
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            TakeDamage(collisionDamage); 
            enemy.TakeDamage(collisionDamage);
        }
    }
}
