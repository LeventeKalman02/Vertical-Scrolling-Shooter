using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float delayTime = 1f;
    public AudioSource src;

    //function for enemy health
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    //function to handle enemy death
    public void Die()
    {
        StartCoroutine(DeathDelay());
        Destroy(gameObject);
    }

    //delay the death of an enemy to play death sound effect
    private IEnumerator DeathDelay()
    { 
        //wait for one second
        WaitForSeconds delay = new WaitForSeconds(delayTime);
        src.Play();

        //disble the sprite render so that the enemy cannot be seen in game
        Enemy enemy = GetComponent<Enemy>();
        enemy.GetComponent<SpriteRenderer>().enabled = false;

        yield return delay;
    }

}
