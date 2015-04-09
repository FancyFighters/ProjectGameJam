using UnityEngine;
using System.Collections;

public class Player_2_Shooting : MonoBehaviour {

	public GameObject bullet;
	[Range(0, 100)]
	public float speed = 20;
	public float lifetime = 2;
	bool changed;
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && changed == true) {
			GameObject clone = (GameObject)Instantiate(bullet, transform.position,Quaternion.identity);
			clone.GetComponent<Rigidbody2D>().velocity = (Vector2.right * -1) * speed;

			Destroy(clone,lifetime);
		}
	}	

	void ChangeRotation(bool change) {
		changed = change;
	}
}
