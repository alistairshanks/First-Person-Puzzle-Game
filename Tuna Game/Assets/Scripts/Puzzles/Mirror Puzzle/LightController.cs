using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightController : MonoBehaviour
{

    /*This class turns handles the logic for switching the lights on and off,
    depending on which stage the puzzle is at. The events are sent to RaycastReflection class */

    //reference to PuzzleStageHandler which sends info on whether to turn lights on or off
    [SerializeField] private PuzzleStageHandler puzzleStageHandler;

    //references to the two light sources, each containing their own RaycastReflection class


    [SerializeField] private RaycastReflection[] lightSourceArray;

    private bool lightSwitchOn = false;


    private void Start()
    {
        //turn light source 1 on for first stage
        lightSourceArray.FirstOrDefault(x => (int)x.MyLightSourceID == 0).LightIsOn = true;
    }

    //function which receives info via the LightControl event in PuzzleStageHandler class
    // then handles logic and controls a bool on the RaycastReflection class
    public void OnLightControl(int whichLightSource, int OnOff)
    {
        
        if (OnOff > 0)
        {
            lightSwitchOn = true;
        }
        else
        {
            lightSwitchOn = false;
        }

        lightSourceArray[whichLightSource].LightIsOn = lightSwitchOn;


    }

    private void OnEnable()
    {
        if (puzzleStageHandler != null)
        {
            //puzzleStageHandler.LightControl += OnLightControl;
            puzzleStageHandler.NewLightControl += OnLightControl;
        }
    }

    private void OnDisable()
    {
        if (puzzleStageHandler != null)
        {
            puzzleStageHandler.NewLightControl -= OnLightControl;
        }
    }



}
