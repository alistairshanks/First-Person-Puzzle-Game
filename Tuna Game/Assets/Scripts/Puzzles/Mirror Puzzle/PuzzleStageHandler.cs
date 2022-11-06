using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleStageHandler : MonoBehaviour
{
    /*
    This class receives info on which puzzle target has been hit and which light source was
    used to hit it from event in MirrorPuzzleTarget class. Then uses switch function to handle
    logic for which stage of the puzzle the player is on, sends event out to say whether lights
    should be on or off.
    */



    //reference to the puzzle targets which will send an event
    [SerializeField] private MirrorPuzzleTarget[] puzzleTargetsToObserve;

    //stores which stage puzzle is at, used in the switch function
    [SerializeField] private int puzzleStage = 0;

    //stores whether player hit puzzle target 3 or 4 first as these can be done in either order
    private bool playerHitPuzzleTarget3First;
    
    //action to send to LightController class to turn lights on and off
    public event Action<int, bool> LightControl;





    private void OnRayEvent(int whichLightSource, int puzzleTargetNumber)
    {
        //Debug.Log("event was received and the light was sent by light source " + whichLightSource);

        switch (puzzleStage)
        {
            case 0:
                if (whichLightSource == 1 && puzzleTargetNumber == 1)
                {
                    //turn off light source 1, turn on light source 2
                    LightControl(1, false);
                    LightControl(2, true);

                    Debug.Log("You have solved the first part of the puzzle");

                    puzzleStage++;
                }

                break;

            case 1:
                if (whichLightSource == 2 && puzzleTargetNumber == 2)
                {
                    //turn light source 1 back on and keep light source 2 on
                    LightControl(1, true);
                    LightControl(2, true);

                    Debug.Log("You have solved the second part of the puzzle");

                    puzzleStage++;
                }

                break;
           
                //part 3 and 4 of puzzle can be done in either order, uses a bool to check which order
                //the player chooses.

            case 2:
                if (whichLightSource == 1 && puzzleTargetNumber == 3)
                {
                    //keep both lights on
                    Debug.Log("You have solved the third part of the puzzle");
                    puzzleStage++;

                    playerHitPuzzleTarget3First = true;
                }

                else if (whichLightSource == 2 && puzzleTargetNumber == 4)
                {
                    //keep both lights on 
                    Debug.Log("You have solved the third part of the puzzle");
                    puzzleStage++;

                    playerHitPuzzleTarget3First = false;
                }
                
                break;

            case 3:
                if (whichLightSource == 1 && puzzleTargetNumber == 3 && !playerHitPuzzleTarget3First)
                {
                    //turn all lights off
                    LightControl(1, false);
                    LightControl(2, false);
                    Debug.Log("You have solved the whole of the puzzle");
                    puzzleStage++;
                }

                else if (whichLightSource == 2 && puzzleTargetNumber == 4 && playerHitPuzzleTarget3First)
                {
                    //turn all lights off
                    LightControl(1, false);
                    LightControl(2, false);
                    Debug.Log("You have solved the whole of the puzzle");
                    puzzleStage++;
                }
                

                break;

            default:

                break;

        }

    }

    private void Awake()
    {
        for ( int i = 0; i < puzzleTargetsToObserve.Length; i++)

        if (puzzleTargetsToObserve[i] != null)
        {
            puzzleTargetsToObserve[i].rayEvent += OnRayEvent;
        }
     


    }





    private void OnDestroy()
    {
        for (int i = 0; i < puzzleTargetsToObserve.Length; i++)

            if (puzzleTargetsToObserve[i] != null)
            {
                puzzleTargetsToObserve[i].rayEvent -= OnRayEvent;
            }
    }

}
