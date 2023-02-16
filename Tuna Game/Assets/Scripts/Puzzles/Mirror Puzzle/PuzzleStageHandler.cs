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

    //stores which stage puzzle is at, used in the switch function
    private int currentPuzzleStage = 0;


    //action to send to LightController class to turn lights on and off
    public event Action<int, int> NewLightControl;

    public TextDisplayController myTextDisplayController;

    [SerializeField] private List<PuzzleStage> puzzleStages;

    // expose a list of lists in the inspector, the index in main list determines puzzle stage
    // values of lists within the main list determine the light switches
    [System.Serializable]
    public class LightSwitchNumbers
    {
        public List<int> sampleList;
    }
    [Tooltip("Index of main list determines puzzle stage, values of list within list determine lights on and off")]
    [Header("PuzzleStage Light Switch Settings ")]
    public List<LightSwitchNumbers> listOfSwitchNumbers = new List<LightSwitchNumbers>();


    private void OnRayEvent(int puzzleStageNumber)
    {
        

        for (int i = puzzleStages.Count - 1; i >= 0; i--)
        {
            if (puzzleStages[i].isCompleted)
            {
                //here we send the Light Control event passing puzzle stage number as the index then access the list and pass indexes 0 1 as the ints
                NewLightControl(0, listOfSwitchNumbers[currentPuzzleStage].sampleList[0]);
                NewLightControl(1, listOfSwitchNumbers[currentPuzzleStage].sampleList[1]);


                Debug.Log("You have solved puzzle part" + currentPuzzleStage);

                // myTextDisplayController.ShowText("You have solved the entire the puzzle");

                currentPuzzleStage++;
                puzzleStages.RemoveAt(i);
            }

        }

    }

    // subscribe to events
    private void Awake()
    {
        for (int i = 0; i < puzzleStages.Count; i++)
        {

            if (puzzleStages[i] != null)
            {
                puzzleStages[i].rayEvent += OnRayEvent;
            }
        }
    }

    private void OnEnable()
    {
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
        for (int i = 0; i < puzzleStages.Count; i++)
        {

            if (puzzleStages[i] != null)
            {
                puzzleStages[i].rayEvent -= OnRayEvent;
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < puzzleStages.Count; i++)
        {

            if (puzzleStages[i] != null)
            {
                puzzleStages[i].rayEvent -= OnRayEvent;
            }
        }
    }

}
