using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
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


        Destroy(gameObject);
    }
}
