using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationPuzzleHandler : MonoBehaviour
{

    //still in progress, put on hold while I rework mirror puzzle 


    [SerializeField] private int[] correctSequence;

    public bool randomSequence;

    private void Start()
    {
        if (randomSequence)
        {
            correctSequence = new int[] { Random.Range(0, 9), Random.Range(0, 9), Random.Range(0, 9), Random.Range(0, 9), };
        }


        for (int i = 0; i < correctSequence.Length; i++)
        {
            Debug.Log(correctSequence[i]);
        }
      
    }


}
