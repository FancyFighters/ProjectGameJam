﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameLogic : MonoBehaviour {

	public GameObject[] leftSegments;
	public GameObject[] rightSegments;
	public GameObject[] middleWallSegments;
	private Vector3 nextLeftSegmentPosition;
	private Vector3 nextRightSegmentPosition;
	private Vector3 nextMiddleWallSegmentPosition;
	public List<GameObject> spawnedLeftSegments = new List<GameObject>();
	public List<GameObject> spawnedRightSegments = new List<GameObject>();
	public List<GameObject> spawnedMiddleWallSegments = new List<GameObject>();
	public float objectHeight = 1f;
	public float wallWidth = 1f;
	public float segmentWidth = 1f;
	public float spawningTime = 6f;
	private float timer = 0f;

	void Start () 
	{

		nextLeftSegmentPosition = new Vector3 (0, 0, 0);
		nextRightSegmentPosition = new Vector3 (segmentWidth + wallWidth, 0, 0);
		nextMiddleWallSegmentPosition = new Vector3 ((segmentWidth / 2)+ (wallWidth / 2), 0, 0);
		spawnSegments ();



	}

	void spawnSegments () 
	{



			int randLeftSegment = Random.Range (0, leftSegments.Length - 1);
			int randRightSegment = Random.Range (0, rightSegments.Length - 1);
			int randWallSegment = Random.Range (0, middleWallSegments.Length - 1);

			//left -------------------------------------------------------------------------------------------------------
			GameObject currLeftSegment = Instantiate (leftSegments [randLeftSegment], nextLeftSegmentPosition, Quaternion.identity) as GameObject;
			spawnedLeftSegments.Add (currLeftSegment);
			nextLeftSegmentPosition += new Vector3 (0, objectHeight, 0);
			//right ------------------------------------------------------------------------------------------------------
			GameObject currRightSegment = Instantiate (rightSegments [randRightSegment], nextRightSegmentPosition, Quaternion.identity) as GameObject;
			spawnedRightSegments.Add (currRightSegment);
			nextRightSegmentPosition += new Vector3 (0, objectHeight, 0);
			//wall -------------------------------------------------------------------------------------------------------
			GameObject currWallSegment = Instantiate (middleWallSegments [randWallSegment], nextMiddleWallSegmentPosition, Quaternion.identity) as GameObject;
			spawnedMiddleWallSegments.Add (currWallSegment);
			nextMiddleWallSegmentPosition += new Vector3 (0, objectHeight, 0);
			
	}

	void Update ()
	{
		if (spawnedLeftSegments.Count > 3)
		{
			Destroy(spawnedLeftSegments[0]);
			spawnedLeftSegments.RemoveAt(0);


		}

		if (spawnedRightSegments.Count > 3)
		{
			Destroy(spawnedRightSegments[0]);
			spawnedRightSegments.RemoveAt(0);
		}

		if (spawnedMiddleWallSegments.Count > 3)
		{
			Destroy(spawnedMiddleWallSegments[0]);
			spawnedMiddleWallSegments.RemoveAt(0);
		}

		timer += Time.deltaTime;

		if (timer > spawningTime) 
		{
			timer -= spawningTime;
			spawnSegments();

		}

	}
}
