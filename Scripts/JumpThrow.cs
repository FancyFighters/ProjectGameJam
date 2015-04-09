using UnityEngine;
using System.Collections;

public class JumpThrow : MonoBehaviour {

	public PolygonCollider2D platform;
	public bool oneWay = false;

	void Update () 
	{
		//platform.enabled = !oneWay; 
		if (oneWay)
			platform.enabled=false;
		if (!oneWay)
			platform.enabled=true;   
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		oneWay = true;
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		oneWay = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		oneWay = false;
	}
}
