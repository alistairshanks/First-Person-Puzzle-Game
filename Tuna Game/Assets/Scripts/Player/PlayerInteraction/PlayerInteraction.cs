using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    /*
     This class sends a ray out in front of player and checks if they press F. If they do
     and the ray hits something which has a class containing the function PlayerInteract()
     then this function is triggered. This allows player to interact with any objects containing
     a class which inherits from PlayerInteractable class.
    */


    //variable for how far the ray should go in front of player
    public float playerReach;



  
    private Ray playerInteractionRay;
    private RaycastHit hit;
    
    //reference for the orientation of the player taken from movement script
    public Transform playerOrientation;



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
                var interactable = hit.transform.GetComponent<PlayerInteractable>();
                if (interactable != null)
                    interactable.PlayerInteract();
            }
        }


        
    }

    //Draws line to represent ray for the direction and reach of player
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Vector3 drawDirection = playerOrientation.forward * playerReach;

        Gizmos.DrawRay(playerInteractionRay.origin, drawDirection);
    }

}
