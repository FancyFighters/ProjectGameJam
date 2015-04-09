using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		while(true) {
			StartCoroutine("Move");
			break;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition += new Vector3(0,0.05f,0);
	}

	IEnumerator Move() {
		print("Move");



		yield return null;
	}
}
