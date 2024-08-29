using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int collisionDamage = 25;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //function for player health
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Die();
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
