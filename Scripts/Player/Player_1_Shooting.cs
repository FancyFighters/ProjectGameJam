using UnityEngine;
using System.Collections;

public class Player_1_Shooting : MonoBehaviour {
	
	public GameObject bullte;
	public GameObject player;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Minus))
		{
			Instantiate(bullte, player.transform.position,Quaternion.identity);
		}
	
	}	
}
