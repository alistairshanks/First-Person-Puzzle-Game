using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleStage : MonoBehaviour

{
    //List of puzzle stages which must be completed before this one can be
    public List<PuzzleStage> prerequisitepuzzleStages;

    public bool isCompleted;
    public int requiredLightSourceID;
    public int puzzleStageNumber;
    public event Action<int> rayEvent;


    public void HitByRay(LightSourceID whicheverLightSource)
    {
        //check if there were other puzzle stages to be completed first
        if (prerequisitepuzzleStages.Count > 0)
        {
            if (CanBeSolved())
            {
                //if they were check if the lightsource is correct
                if ((int)whicheverLightSource == requiredLightSourceID)

                {
                    //complete this puzzle stage and pass the ray event to puzzleStageHandler
                    isCompleted = true;
                    rayEvent(puzzleStageNumber);
                }
            }
        }

        //if there were no puzzle stages to be completed first then check if the lightsource is correct
        else
        {
            if ((int)whicheverLightSource == requiredLightSourceID)
            {
                Debug.Log("harry potter");
                //complete this puzzle stage and pass the ray event to puzzleStageHandler
                isCompleted = true;
                rayEvent(puzzleStageNumber);
            }
        }

    }


    //check for prerequesite puzzle stages
    private bool CanBeSolved()
    {
        //if any prerequisite puzzle stages have been solved then remove them from the list
        for (int i = 0; i < prerequisitepuzzleStages.Count; i++)
        {
            if (prerequisitepuzzleStages[i].isCompleted == true)
            {
                prerequisitepuzzleStages.RemoveAt(i);
            }
        }

        // of the list is empty then can be solved is true, if not then
        // the puzzle stage is not yet ready to be solved
        if (prerequisitepuzzleStages.Count > 0)
        {
            return false;
        }

        else
        {
            return true;
        }

    }
}
