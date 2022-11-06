﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{

	public int whichLightSource = 1;

	//number of reflections that we want
	public int reflections;

	//how long the raycast will be
	public float maxLength;

	//line renderer variable
	private LineRenderer lineRenderer;
	private Ray ray;
	private RaycastHit hit;

	public bool lightIsOn = false;

	private void Awake()
	{
		// get the line renderer component from game object and assign to variable
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (lightIsOn)
		{ 
		TurnLightOn();
		}

		else if (!lightIsOn)
        {
			this.lineRenderer.positionCount = 0;
        }
	}


	public void TurnLightOn()
    {
		//set starting point and direction of ray
		ray = new Ray(transform.position, -transform.forward);

		// sets the amount of vertices to 2 (0 and 1)
		lineRenderer.positionCount = 1;
		//set the position of the first point on the line renderer
		lineRenderer.SetPosition(0, transform.position);

		float remainingLength = maxLength;

		// make a for loop and set the length to reflections
		for (int i = 0; i < reflections; i++)
		{
			//check if raycast hits anything
			if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
			{

				/*  Try to get the class MirrorPuzzleTarget and if it is present
				then call the desired function for the next stage of the puzzle   */
				MirrorPuzzleTarget mPT = hit.transform.GetComponent<MirrorPuzzleTarget>();
				if (mPT != null)
				{
					mPT.HitByRay(whichLightSource);
				}



				//increase vertex count by 1 (each time we loop and hit something)
				lineRenderer.positionCount += 1;
				//set position of next vertex to point where raycast hits something
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

				remainingLength -= Vector3.Distance(ray.origin, hit.point);
				ray = new Ray(hit.point + hit.normal * 0.001f, Vector3.Reflect(ray.direction, hit.normal));
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

