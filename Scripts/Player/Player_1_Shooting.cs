using UnityEngine;
using System.Collections;

public class Player_1_Shooting : MonoBehaviour {
	
	public GameObject bullet;
	[Range(0,100)]
	public float speed = 20;
	public float lifetime = 2;
	bool changed;

	void Start() {
	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Minus) && changed == true) {
			GameObject clone = (GameObject)Instantiate(bullet, transform.position,Quaternion.identity);
			clone.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
			Destroy(clone, lifetime);
		}
	}	

	void ChangeRotation(bool change) {
		changed = change;
	}
}

