using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {


	public Vector2 speed = new Vector2(6f, 0);
	Rigidbody2D bulletBody;

	void Start () {  

		bulletBody = GetComponent <Rigidbody2D>();
//		Vector2 bulletbodyVelocity = Rigidbody2D.velocity;
//		bulletbodyVelocity.x = speed;
		bulletBody.AddForce (speed, ForceMode2D);
	}
	

	void OnBecameInvisible() {  

		Destroy(gameObject);
	}
}
