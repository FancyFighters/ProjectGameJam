using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public bool Player1;

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;

	Animator anim;

	void Start () {
		controller = GetComponent<Controller2D>();
		anim = GetComponent<Animator>();

		gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void Update () {
		Movement();
	}

	void Movement() {
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		Vector2 input;
		
		if(controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
		
		if(Player1) {
			input = new Vector2 (Input.GetAxisRaw("Player 1 Horizontal"), Input.GetAxisRaw("Player 1 Vertical"));
			
			if(Input.GetKeyDown(KeyCode.UpArrow) && controller.collisions.below) {
				velocity.y = jumpVelocity;
			}
			
		} else {
			input = new Vector2 (Input.GetAxisRaw("Player 2 Horizontal"), Input.GetAxisRaw("Player 2 Vertical"));
			
			if(Input.GetKeyDown(KeyCode.W) && controller.collisions.below) {
				velocity.y = jumpVelocity;
			}
		}
		
		if(Input.GetAxisRaw("Horizontal") > 0) {
			transform.localScale = new Vector3(1, 1, 1);
		}
		
		if(Input.GetAxisRaw("Horizontal") < 0) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
		
		
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}
