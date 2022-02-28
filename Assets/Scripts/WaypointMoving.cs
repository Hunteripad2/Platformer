using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMoving : MonoBehaviour
{
    [HideInInspector] private SpriteRenderer sprite;
    [HideInInspector] private int currentWaypointIndex;

    [Header("Movement")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private GameObject[] waypoints;

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
