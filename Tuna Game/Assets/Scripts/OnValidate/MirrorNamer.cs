using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorNamer : MonoBehaviour
{

    //class used to quickly name an array of objects in editor with a chosen name then a number


    [SerializeField] private GameObject[] mirrors;

    private void OnValidate()
    {
        for (int i = 0; i < mirrors.Length; i++)
        {
            mirrors[i].name = "Mirror " + (i+1);
        }
    }
}
