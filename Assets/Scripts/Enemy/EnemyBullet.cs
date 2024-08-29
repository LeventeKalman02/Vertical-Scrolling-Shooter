using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    public int damage = 25;
    private GameObject player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player");

        rb.velocity = Vector2.down * speed;

    }

    //detect collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the object hit is an enemy
        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        //if enemy is not NULL call the take damage function from the enemy script
        if (player != null)
        {
            player.TakeDamage(damage);
            //destroy the bullet
            Destroy(gameObject);
        }
        //destroy the bullet after x amount of time
        Destroy(gameObject, .6f);
    }
}
