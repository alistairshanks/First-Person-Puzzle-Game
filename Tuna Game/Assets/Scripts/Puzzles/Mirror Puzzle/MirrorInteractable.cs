using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInteractable : MonoBehaviour, PlayerInteractable
{
    // allows the player to turn the mirror by using the PlayerInteract() function and rotating it 45 degrees
    //the PlayerInteract funtion is triggered by message sent from PlayerInteraction class.

    
    //set up a vector3 containing the number of degrees by which to rotate the mirror
    private Vector3 rotationOfMirror = new Vector3(0, 45, 0);
    
    public void PlayerInteract()
    {
      //add the rotation factor onto the current rotation of the mirror.
      transform.eulerAngles = transform.eulerAngles + rotationOfMirror;
    }

 
}
