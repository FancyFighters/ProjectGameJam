using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class gameLogic : MonoBehaviour {

	public Transform[] segments;
	private Vector3 nextSegment;
	public List<Transform> spawnedSegments = new List<Transform>();
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
		int randSegment = Random.Range (0, segments.Length);
		Transform currSegment = Instantiate (segments [randSegment], nextSegment, Quaternion.identity) as Transform;
		spawnedSegments.Add (currSegment);

		nextSegment += new Vector3 (0, objectHeight, 0);
		print (nextSegment);
		Invoke ("spawnSegments", 0.5f);
	}

	void destroySegments ()
	{
	}
}
