using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRandomiser : MonoBehaviour
{

    //create an array to store the mirrors
    public GameObject[] arrayOfMirrors;

    //create an array to hold the possible angles for mirrors to be at
    private Vector3[] arrayOfAngles = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 45, 0), new Vector3(0, 90, 0), new Vector3(0, 135, 0) };


    private void Start()
    {


        //loop through array of mirrors and set each one to a random index of our array of angles
        for (int i = 0; i < arrayOfMirrors.Length; i++)
        {
            arrayOfMirrors[i].transform.eulerAngles = arrayOfAngles[Random.Range(0, arrayOfAngles.Length)];


        }
    }
}
