using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameLogic : MonoBehaviour {

	public GameObject[] segments;
	private Vector3 nextSegment;
	public List<GameObject> spawnedSegments = new List<GameObject>();
	public float objectHeight = 5f;

	// Use this for initialization
	void Start () 
	{
		spawnSegments ();
		nextSegment = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void spawnSegments () 
	{
		int randSegment = Random.Range (0, segments.Length-1);
		//Debug.Log (segments[0]);
		GameObject currSegment = Instantiate (segments [randSegment], nextSegment, Quaternion.identity) as GameObject;
		spawnedSegments.Add (currSegment);

		nextSegment += new Vector3 (0, objectHeight, 0);
		print (nextSegment);
		Invoke ("spawnSegments", 2f);

	}

	void Update ()
	{
		if (spawnedSegments.Count > 3)
		{
			//print (spawnedSegments[0]);
			Destroy(spawnedSegments[0]);
			spawnedSegments.RemoveAt(0);
		}
	}
}
