using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletPos;

    private float timer;
    public float timerInterval = 1f;

    // Update is called once per frame
    void Update()
    {
        //make sure timer is in seconds
        timer += Time.deltaTime;

        if(timer >= timerInterval)
        {
            timer = 0;
            Shoot();
        }
    }

    //enemy shooting funtion
    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
    }
}
