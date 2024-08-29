using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioSource src;

    // Update is called once per frame
    void Update()
    {
        //get the input for shooting
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
            //play the shooting audio sound
            src.Play();
        }
    }

    //function for spawning the bullet and shooting
    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
