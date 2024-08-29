using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //move the bullet using the velocity of the rigidbody
        rb.velocity = transform.up * speed;
    }

    //detect collision with enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the object hit is an enemy
        Enemy enemy = collision.GetComponent<Enemy>();
        
        //if enemy is not NULL call the take damage function from the enemy script
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            //destroy the bullet
            Destroy(gameObject);
        }
        //destroy the bullet after x amount of time
        Destroy(gameObject, .6f);
    }
}
