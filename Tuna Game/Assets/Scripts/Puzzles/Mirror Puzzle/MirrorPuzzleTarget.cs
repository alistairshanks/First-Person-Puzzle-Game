using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MirrorPuzzleTarget : MonoBehaviour
{
  /*
  
    This class contains a number for each puzzle target and an event. The event
    is sent out whenever it is hit by a ray. This is done by the RaycastReflection class.
    The RaycastReflection class also sends a number indicating which light source the ray came from.
    This event is then listened to by the PuzzleStageHandler class to handle puzzle logic.

  */

    public int puzzleTargetNumber;
    public event Action<int, int> rayEvent;

    public void HitByRay( int whicheverLightSource)
    {
        if (rayEvent != null)
        {
            rayEvent(whicheverLightSource, puzzleTargetNumber);
        }


        
    }





}
