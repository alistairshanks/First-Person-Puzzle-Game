using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    /*This class turns handles the logic for switching the lights on and off,
    depending on which stage the puzzle is at. The events are sent to RaycastReflection class */

    //reference to PuzzleStageHandler which sends info on whether to turn lights on or off
    [SerializeField] 
    private PuzzleStageHandler puzzleStageHandler;

    //references to the two light sources, each containing their own RaycastReflection class
    public RaycastReflection lightSource1;
    public RaycastReflection lightSource2;


    private void Start()
    {
        //turn light source 1 on for first stage
        lightSource1.lightIsOn = true;
    }

    //function which receives info via the LightControl event in PuzzleStageHandler class
    // then handles logic and controls a bool on the RaycastReflection class
    void OnLightControl(int whichLightSource, bool onOff)
    {
        if (whichLightSource == 1 && onOff == false)
        {
            lightSource1.lightIsOn = false;
        }

        if (whichLightSource == 1 && onOff == true)
        {
            lightSource1.lightIsOn = true;
        }

        if (whichLightSource == 2 && onOff == false)
        {
            lightSource2.lightIsOn = false;
        }

        if (whichLightSource == 2 && onOff == true)
        {
            lightSource2.lightIsOn = true;
        }
    }

    private void Awake()
    {
        if (puzzleStageHandler != null)
        { 
        puzzleStageHandler.LightControl += OnLightControl;
        }

    }

    private void OnDestroy()
    {
        if (puzzleStageHandler != null)
        {
            puzzleStageHandler.LightControl -= OnLightControl;
        }
    }


}
