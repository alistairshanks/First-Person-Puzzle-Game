using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPuzzleHandler : MonoBehaviour
{
   /* public GameObject lightSource1;
    public GameObject lightSource2;
    public GameObject lightDestination1;
    public GameObject lightDestination2;
    public GameObject lightDestination3;
    public GameObject lightDestination4;
   */

	private Ray ray;
	private RaycastHit hit;

	private int puzzleStage = 2;

	//number of reflections that we want
	public int reflections;

	//how long the raycast will be
	public float maxLength;

	public Transform lightSourceTransform1;
	public Transform lightSourceTransform2;
	public LineRenderer lineRenderer1;
	public LineRenderer lineRenderer2;







    private void Update()
    {
		// call sendlight function and define a transform and line renderer, a lightsource ID and which stage the puzzle is at
		SendLight(lightSourceTransform1, lineRenderer1, 1, puzzleStage);
		SendLight(lightSourceTransform2, lineRenderer2, 2, puzzleStage);

    }




	private void PuzzlePartSolved(int whichPuzzleStage)
    {
		if (whichPuzzleStage == 2)
        {
			//do whatever happens after solving first puzzle part
			Debug.Log("puzzle 1 solved");
        }

		else if (whichPuzzleStage == 3)
        {
			//do whatever happens after solving second puzzle part
			Debug.Log("puzzle 2 solved");
        }

		else if (whichPuzzleStage == 4)
        {
			//do whatever happens after solving third puzzle
			Debug.Log("puzzle 3 solved");
        }

		else if (whichPuzzleStage == 5)
		{
			//do whatever happens after solving third puzzle
			Debug.Log("puzzle 4 solved");
		}



		//add 1 to current puzzle stage
		puzzleStage += 1;

    }



    private void SendLight(Transform thisLightSourceTransform, LineRenderer lineRenderer, int lightSourceID, int thisPuzzleStage)
    {
		{

			//send a ray forward
			ray = new Ray(thisLightSourceTransform.position, -thisLightSourceTransform.forward);
			// sets the amount of vertices to 2 (0 and 1)
			lineRenderer.positionCount = 1;
			//set the position of the first point on the line renderer
			lineRenderer.SetPosition(0, thisLightSourceTransform.position);

			float remainingLength = maxLength;

			// make a for loop and set the length to reflections
			for (int i = 0; i < reflections; i++)
			{
				//check if raycast hits anything
				if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
				{

					//increase vertex count by 1 (each time we loop and hit something)
					lineRenderer.positionCount += 1;
					//set position of next vertex to point where raycast hits something
					lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

					remainingLength -= Vector3.Distance(ray.origin, hit.point);
					ray = new Ray(hit.point + hit.normal * 0.001f, Vector3.Reflect(ray.direction, hit.normal));


					//if tag = the current puzzle stage then call puzzle part solved function
					int result;
					int.TryParse(hit.collider.tag, out result);
					if (result == thisPuzzleStage)
                    {
						PuzzlePartSolved(thisPuzzleStage);
                    }

                      
                
					if (hit.collider.tag != "Mirror")
						break;
				}
				else
				{
					// if ray cast does not hit anything set position count to +1 of what it's at
					lineRenderer.positionCount += 1;
					lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
				}
			}
		}
	}
}

