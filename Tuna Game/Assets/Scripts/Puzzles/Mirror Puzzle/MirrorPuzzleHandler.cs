using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPuzzleHandler : MonoBehaviour
{

	private Ray ray;
	private RaycastHit hit;

	private int puzzleStage = 1;

	//number of reflections that we want
	public int reflections;

	//how long the raycast will be
	public float maxLength;

	public Transform lightSourceTransform1;
	public Transform lightSourceTransform2;
	public LineRenderer lineRenderer1;
	public LineRenderer lineRenderer2;


	//create an array to store the mirrors
	public GameObject[] arrayOfMirrors;

	//create an array to hold the possible angles for mirrors to be at
	private Vector3[] arrayOfAngles = new Vector3[] {new Vector3(0,0,0), new Vector3(0,45,0), new Vector3(0,90,0), new Vector3(0,135,0) };



    private void Start()
    {
		//loop through array of mirrors and set each one to a random index of our array of angles
		for (int i = 0; i < arrayOfMirrors.Length; i++)
		{
			arrayOfMirrors[i].transform.eulerAngles = arrayOfAngles[Random.Range(0, arrayOfAngles.Length)];


        }
    }





    private void Update()
    {
		// switch statement to turn each light on and off, passing a transform, a line renderer and which stage the puzzle is at.

		switch (puzzleStage)
        {
			

			case 1: SendLight(lightSourceTransform1, lineRenderer1, puzzleStage);
				Debug.Log("you are on puzzle stage 1");
				break;

            case 2:
				SendLight(lightSourceTransform2, lineRenderer2, puzzleStage);
				lineRenderer1.positionCount = 0;
				Debug.Log("you are on puzzle stage 2");
				break;

			case 3:
				SendLight(lightSourceTransform1, lineRenderer1, puzzleStage);
				SendLight(lightSourceTransform2, lineRenderer2, puzzleStage);
				Debug.Log("you are on puzzle stage 3");
				break;


			case 4:
				SendLight(lightSourceTransform1, lineRenderer1, puzzleStage);
				SendLight(lightSourceTransform2, lineRenderer2, puzzleStage);
				Debug.Log("you are on puzzle stage 4");
				break;


			case 5:
				lineRenderer1.positionCount = 0;
				lineRenderer2.positionCount = 0;
				Debug.Log("puzzle solved");

				break;

			default: break;
		}


    }




	private void PuzzlePartSolved(int whichPuzzleStage)
    {
		if (whichPuzzleStage == 1)
        {
			//do whatever happens after solving first puzzle part

        }

		else if (whichPuzzleStage == 2)
        {
			//do whatever happens after solving second puzzle part

        }

		else if (whichPuzzleStage == 3)
        {
			//do whatever happens after solving third puzzle

        }

		else if (whichPuzzleStage == 4)
		{
			//do whatever happens after solving third puzzle
		
		}



		//add 1 to current puzzle stage
		puzzleStage += 1;

    }



    private void SendLight(Transform thisLightSourceTransform, LineRenderer lineRenderer, int thisPuzzleStage)
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

