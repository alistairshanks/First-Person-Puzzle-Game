using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorNamer : MonoBehaviour
{
    public GameObject[] mirrors;


    private void OnValidate()
    {
        for (int i = 0; i < mirrors.Length; i++)
        {
            mirrors[i].name = "Mirror " + (i+1);
        }
    }
}
