using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionerFromReference : ObjectPositioner
{

    /*
     Class for preciesly positioning object with reference to the position of a chosen object.
    Allows for if object is under same parent or not. Doesn't quite work for everything lol :)
    */
     
   
    public void OnValidate()
    {

        if (underSameParent)
        {
            //check we have reference object to avoid errors
            if (referenceObject != null)
            {
                //add on distance  for x and z axis
               
                newPosition.x = referenceObject.localPosition.x + xDistance;
                newPosition.y = referenceObject.localPosition.y + yDistance;
                newPosition.z = referenceObject.localPosition.z + zDistance;
            

                //set position
                transform.localPosition = newPosition;
            }

            //add log warning to let designer know something has not been set that could be
            else
            {
                Debug.LogWarning("No reference object set", referenceObject);
            }
        }

        else 
        {
            //check we have reference object to avoid errors
            if (referenceObject != null)
            {
                //add on distance  for x and z axis

                newPosition.x = referenceObject.transform.position.x + xDistance;
                newPosition.y = referenceObject.transform.position.y + yDistance;
                newPosition.z = referenceObject.transform.position.z + zDistance;

                //set position
                transform.position = newPosition;
            }

            //add log warning to let designer know something has not been set that could be
            else
            {
                Debug.LogWarning("No reference Object set", referenceObject);
            }

        }
    }
}
