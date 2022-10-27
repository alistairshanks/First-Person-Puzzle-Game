using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositioner : MonoBehaviour
{
    //variable for whatever the reference object is
    public Transform referenceObject;

    //variable to hold new position
    public Vector3 t = new Vector3 (0, 0, 0);

    
    //distance you would like objects from reference objects
    public float xDistance;
    public float zDistance;

    private void OnValidate()
    {
        //check we have reference object to avoid errors
        if (referenceObject != null)
        {
            //add on distance  for x and z axis
            t.z = referenceObject.localPosition.z + zDistance;
            t.x = referenceObject.localPosition.x + xDistance;

            //keep y axis the same
            t.y = transform.localPosition.y;

            //set position
            transform.localPosition = t;
        }

        
    }
}
