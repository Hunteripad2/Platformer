using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector] private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float posY = transform.position.y;
        if (player.position.y > -2.5f && player.position.y < 2.5f)
        {
            posY = player.position.y;
        }
        transform.position = new Vector3(player.position.x, posY, transform.position.z);
    }
}
