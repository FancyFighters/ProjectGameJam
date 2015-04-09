using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameLogic : MonoBehaviour {

	public GameObject[] segments;
	private Vector3 nextSegmentPosition;
	public List<GameObject> spawnedSegments = new List<GameObject>();
	public float objectHeight = 20f;

	// Use this for initialization
	void Start () 
	{
		nextSegmentPosition = new Vector3 (0, 0, 0);
		spawnSegments ();

	}
	
	// Update is called once per frame
	void spawnSegments () 
	{
		int randSegment = Random.Range (0, segments.Length-1);
		//Debug.Log (segments[0]);
		GameObject currSegment = Instantiate (segments [randSegment], nextSegmentPosition, Quaternion.identity) as GameObject;
		print ("rdh" + currSegment.transform.position);
		spawnedSegments.Add (currSegment);

		nextSegmentPosition += new Vector3 (0, objectHeight, 0);
		Invoke ("spawnSegments", 2f);

	}

	void Update ()
	{
		if (spawnedSegments.Count > 3)
		{
			Destroy(spawnedSegments[0]);
			spawnedSegments.RemoveAt(0);
		}
	}


}
