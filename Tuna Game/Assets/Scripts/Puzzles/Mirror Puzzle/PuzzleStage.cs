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
    public event Action<LightSourceID, int> rayEvent;


    void CompletePuzzleStage()
    {
        isCompleted = true;
    }

    public void HitByRay(LightSourceID whicheverLightSource)
    {
        //check if rayevent is not null
        if (rayEvent != null)
        {
            //check if there were other puzzle stages to be completed first
            if (prerequisitepuzzleStages != null)
            {
                //loop through the ones that had to be completed first and check if they were completed
                for (int i = 0; i < prerequisitepuzzleStages.Count; i++)
                {
                    if (prerequisitepuzzleStages[i].isCompleted == true)
                    {
                        //if they were check if the lightsource is correct
                        if ((int)whicheverLightSource == requiredLightSourceID)
                        

                        //complete this puzzle stage and pass the ray event to puzzleStageHandler
                        isCompleted = true;
                        rayEvent(whicheverLightSource, puzzleStageNumber);
                    }
                }
            }

            //if there were no puzzle stages to be completed first then check if the lightsource is correct
            else if ((int)whicheverLightSource == requiredLightSourceID)
            {
                //complete this puzzle stage and pass the ray event to puzzleStageHandler
                isCompleted = true;
                rayEvent(whicheverLightSource, puzzleStageNumber);
            }

        }



    }
}
