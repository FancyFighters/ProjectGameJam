using UnityEngine;
using System.Collections;

public class Axt : MonoBehaviour {
	
	void FixedUpdate () {
		transform.localPosition += new Vector3(0,-0.05f,0);
	}
	
}
