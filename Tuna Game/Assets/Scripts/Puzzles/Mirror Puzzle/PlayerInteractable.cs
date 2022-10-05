using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    //set up a vector 3 containing the number by which to rotate the mirror
    private Vector3 rotationOfMirror = new Vector3(0, 45, 0);


    public void PlayerInteract()
    {
        Debug.Log("message received");

        if (this.tag == "Mirror") 
        {
            TurnThisMirror();
        }
    }
    





    public void TurnThisMirror()
    {
        //add the rotation factor onto the current rotation of the mirror.
        transform.eulerAngles = transform.eulerAngles + rotationOfMirror;
    }
}
