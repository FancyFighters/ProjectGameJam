using UnityEngine;
using System.Collections;

public class gameLogic : MonoBehaviour {

	public Transform[] segments;
	private Vector3 nextSegment;
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

		Instantiate (segments [Random.Range (0, segments.Length)], nextSegment, Quaternion.identity);
		nextSegment += new Vector3 (0, objectHeight, 0);
		print (nextSegment);
		Invoke ("spawnSegments", 0.5f);

	}
}
