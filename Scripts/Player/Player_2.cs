using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player_2 : MonoBehaviour {

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
	float jumpTime;
	bool jumped;

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
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Player 2 Horizontal")));

		if(controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		Vector2	input = new Vector2 (Input.GetAxisRaw("Player 2 Horizontal"), Input.GetAxisRaw("Player 2 Vertical"));

		if(Input.GetKeyDown(KeyCode.W) && controller.collisions.below) {
			velocity.y = jumpVelocity;
			jumpTime = timeToJumpApex;
			anim.SetTrigger("Jump");
			jumped = true;
		}

		jumpTime -= Time.deltaTime;
		if(jumpTime <= 0 && controller.collisions.below && jumped == true) {
			anim.SetTrigger("Land");
			jumped = false;
		}

		if(Input.GetAxisRaw("Player 2 Horizontal") > 0) {
			transform.localScale = new Vector3(1, 1, 1);
			GameObject.Find("shooter_2").SendMessage("ChangeRotation", false);
		}
		
		if(Input.GetAxisRaw("Player 2 Horizontal") < 0) {
			transform.localScale = new Vector3(-1, 1, 1);
			GameObject.Find("shooter_2").SendMessage("ChangeRotation", true);
		}

		
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Bullet 1") || other.CompareTag("Axt")) {
			Application.LoadLevel(4);
		}
	}
}
