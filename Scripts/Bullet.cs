﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		if (collisionObject.gameObject.tag == "destroysBullet") 
		{
			Destroy (gameObject);
		}
	}
}
