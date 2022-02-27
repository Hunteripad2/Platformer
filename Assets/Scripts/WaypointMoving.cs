using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMoving : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 3f;

    private int currentWaypointIndex = 0;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float currentDistance = Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position);

        if (currentDistance < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            sprite.flipX = !sprite.flipX;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
