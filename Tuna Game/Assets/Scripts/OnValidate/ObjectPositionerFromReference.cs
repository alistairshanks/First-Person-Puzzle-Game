using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionerFromReference : ObjectPositioner
{

    /*
     Class for preciesly positioning object with reference to the position of a chosen object.
    Allows for if object is under same parent or not. Doesn't quite work for everything lol :)
    */
     
   
    public override void OnValidate()
    {

        if (underSameParent)
        {
            //check we have reference object to avoid errors
            if (referenceObject != null)
            {
                //add on distance  for x and z axis
               
                t.x = referenceObject.localPosition.x + xDistance;
                t.y = referenceObject.localPosition.y + yDistance;
                t.z = referenceObject.localPosition.z + zDistance;
            

                //set position
                transform.localPosition = t;
            }
        }

        else if (!underSameParent)
        {
            //check we have reference object to avoid errors
            if (referenceObject != null)
            {
                //add on distance  for x and z axis
               
                t.x = referenceObject.transform.position.x + xDistance;
                t.y = referenceObject.transform.position.y + yDistance;
                t.z = referenceObject.transform.position.z + zDistance;

                //set position
                transform.position = t;
            }


        }
    }
}
