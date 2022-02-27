using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 oldPosition;
    //MiddlegroundMovement[] allMiddlegrounds;

    [SerializeField] private Transform player;

    private void Start()
    {
        oldPosition = this.transform.position;
    }

    private void Update()
    {
        float posY = transform.position.y;
        if (player.position.y > -2.5f && player.position.y < 2.5f)
        {
            posY = player.position.y;
        }
        transform.position = new Vector3(player.position.x, posY, transform.position.z);
        //CheckIfMoved();
    }

    private void CheckIfMoved()
    {
        if (oldPosition != this.transform.position)
        {
            oldPosition = this.transform.position;

            //if (allMiddlegrounds == null)
            //{
            //    allMiddlegrounds = GameObject.FindObjectsOfType<MiddlegroundMovement>();
            //}
            //foreach (MiddlegroundMovement middleground in allMiddlegrounds)
            //{
            //    middleground.UpdatePosition();
            //}
        }
    }
}
