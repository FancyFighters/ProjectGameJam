using UnityEngine;
using System.Collections;

public class Player_2_Shooting : MonoBehaviour {
	
	public GameObject bullet;
	[Range(0,100)]
	public float speed = 20;
	public float lifetime = 2;
	
	public float fireRate;
	private float nextFire;

	bool changed;
	
	void Start() {
	}
	
	void FixedUpdate () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && changed == true && Time.time > nextFire) {
			shoot();
		}
	}	
	
	void shoot() {
		nextFire = Time.time + fireRate;
		GameObject clone = (GameObject)Instantiate(bullet, transform.position,Quaternion.identity);
		clone.GetComponent<Rigidbody2D>().velocity = (Vector2.right * -1) * speed;
		Destroy(clone, lifetime);
	}
	
	void ChangeRotation(bool change) {
		changed = change;
	}
}

