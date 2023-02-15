using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPositioner : MonoBehaviour
{
    //base class for classes for precisely positioning objects in scene

    //variable for whatever the reference object is
    public Transform referenceObject;

    //variable to hold new position
   protected Vector3 newPosition = Vector3.zero;


    //distance you would like objects from reference objects
    public float xDistance;
    public float yDistance;
    public float zDistance;
    

    public bool underSameParent = false;

    
}
