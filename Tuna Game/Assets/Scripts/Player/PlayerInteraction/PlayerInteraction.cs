using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach;

    private Ray playerInteractionRay;
    private RaycastHit hit;

    public Transform playerOrientation;

    private GameObject thisMirror;


    private void Update()
    {
        //create a new ray starting from player position and pointing in direction player is facing
        playerInteractionRay = new Ray(transform.position, playerOrientation.forward);

        //check if ray hits anything and check the tag on whatever it has hit
        if (Physics.Raycast(playerInteractionRay.origin, playerInteractionRay.direction, out hit, playerReach))
        {


            //check if we press the F key and if we do then trigger function on object
            if (Input.GetKeyDown(KeyCode.F))
            {
                //send message
                hit.transform.SendMessage("PlayerInteract");
            }
        }


        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Vector3 drawDirection = playerOrientation.forward * playerReach;

        Gizmos.DrawRay(playerInteractionRay.origin, drawDirection);
    }

}
