using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;



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
    [SerializeField] private int currentPuzzleStage = 0;

    //stores whether player hit puzzle target 3 or 4 first as these can be done in either order
    private bool playerHitPuzzleTarget3First;

    //action to send to LightController class to turn lights on and off
    public event Action<int, bool> LightControl;

    public TextDisplayController myTextDisplayController;

    [SerializeField] private List<PuzzleStage> puzzleStages;
    












    private void OnRayEvent(LightSourceID whichLightSource, int puzzleTargetNumber)
    {
        // ***************trying new method***************

        for (int i = puzzleStages.Count - 1; i >= 0; i--)
        {
            if (puzzleStages[i].isCompleted)
            {
            
                
                /*

                **FIND A WAY TO HAVE SOMETHING IN THE INSPECTOR THAT ALLOWS THE DESIGNER
                TO SET WHICH LIGHTS GO OFF AT EACH PUZZLE STAGE WITHOUT HARD CODING**

                */

                //turn off light source 1, turn on light source 2
                //LightControl(0, false);
               // LightControl(1, true);

                Debug.Log("You have solved the first part of the puzzle");
                puzzleStages.RemoveAt(i);
            }


        }
        
      
        // *******************ORIGINAL METHOD********************

/*
        switch (puzzleStage)
        {
            case 0:
                if ((int)whichLightSource == 0 && puzzleTargetNumber == 1)
                {
                    //turn off light source 1, turn on light source 2
                    LightControl(0, false);
                    LightControl(1, true);

                    Debug.Log("You have solved the first part of the puzzle");

                    puzzleStage++;

                    myTextDisplayController.ShowText("You have solved the first part of the puzzle");


                }

                break;

            case 1:
                if ((int)whichLightSource == 1 && puzzleTargetNumber == 2)
                {
                    //turn light source 1 back on and keep light source 2 on
                    LightControl(0, true);
                    LightControl(1, true);

                    Debug.Log("You have solved the second part of the puzzle");

                    puzzleStage++;

                    myTextDisplayController.ShowText("You have solved the second part of the puzzle");
                }

                break;
           
                //part 3 and 4 of puzzle can be done in either order, uses a bool to check which order
                //the player chooses.

            case 2:
                if ((int)whichLightSource == 0 && puzzleTargetNumber == 3)
                {
                    //keep both lights on
                    Debug.Log("You have solved the third part of the puzzle");
                    puzzleStage++;

                    myTextDisplayController.ShowText("You have solved the third part of the puzzle");
                    playerHitPuzzleTarget3First = true;
                }

                else if ((int)whichLightSource == 1 && puzzleTargetNumber == 4)
                {
                    //keep both lights on 
                    Debug.Log("You have solved the third part of the puzzle");
                    puzzleStage++;

                    myTextDisplayController.ShowText("You have solved the third part of the puzzle");

                    playerHitPuzzleTarget3First = false;
                }
                
                break;

            case 3:
                if ((int)whichLightSource == 0 && puzzleTargetNumber == 3 && !playerHitPuzzleTarget3First)
                {
                    //turn all lights off
                    LightControl(0, false);
                    LightControl(1, false);
                    Debug.Log("You have solved the whole of the puzzle");

                    myTextDisplayController.ShowText("You have solved the entire the puzzle");
                    puzzleStage++;
                }

                else if ((int)whichLightSource == 1 && puzzleTargetNumber == 4 && playerHitPuzzleTarget3First)
                {
                    //turn all lights off
                    LightControl(0, false);
                    LightControl(1, false);
                    Debug.Log("You have solved the whole of the puzzle");

                    myTextDisplayController.ShowText("You have solved the entire the puzzle");
                    puzzleStage++;
                }
                

                break;

            default:

                break;

        }
*/

    }

    // subscribe to events
    private void Awake()
    {
        for (int i = 0; i < puzzleTargetsToObserve.Length; i++)
        {

            if (puzzleTargetsToObserve[i] != null)
            {
                puzzleTargetsToObserve[i].rayEvent += OnRayEvent;
            }
        }

        //part of new method
        for (int i = 0; i < puzzleStages.Count; i++)
        {

            if (puzzleStages[i] != null)
            {
                puzzleStages[i].rayEvent += OnRayEvent;
            }
        }

    }

    //unsubscribe from events

    private void OnDestroy()
    {
        for (int i = 0; i < puzzleTargetsToObserve.Length; i++)

            if (puzzleTargetsToObserve[i] != null)
            {
                puzzleTargetsToObserve[i].rayEvent -= OnRayEvent;
            }

        // part of new method
        for (int i = 0; i < puzzleStages.Count; i++)
        {

            if (puzzleStages[i] != null)
            {
                puzzleStages[i].rayEvent -= OnRayEvent;
            }
        }
    }

}
