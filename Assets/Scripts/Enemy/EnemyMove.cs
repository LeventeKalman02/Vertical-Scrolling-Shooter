using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    //range from the waypoint that the enemy can be before changing direction
    [SerializeField] private float range = 0.5f;
    [SerializeField] private float maxDistance;

    Vector2 waypoint;

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        //move the enemy to a random waypoint withing the maxDistance that is set in the editor
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint) < range)
        {
            SetNewDestination();   
        }
    }

    //set a new waypoint for the enemy to move to 
    private void SetNewDestination()
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}
