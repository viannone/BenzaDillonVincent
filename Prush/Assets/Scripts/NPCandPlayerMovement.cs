using UnityEngine;
using System.Collections;

public class NPCandPlayerMovement : MonoBehaviour {
	public Rigidbody2D rigi;
	public int horizontalSpeed;
	public int jumpVelocity;
	public float jumpTimer;
	public int jumpCooldownTime;
	public bool onGround;

	public float yOffset;

	public float xInput;//values b/w -1, 1
	public float yInput;

	private float xVel;
	private float yVel;

	public float boxCastWidth;
	public float boxCastDistance;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();

		//so you can jump immediately upon instantiation
		jumpTimer = jumpCooldownTime;
	}

	void FixedUpdate () {
		onGround = IsGrounded ();
		jumpTimer += Time.deltaTime;
		rigi.velocity = new Vector2 (xInput * horizontalSpeed, rigi.velocity.y);
		if (yInput > 0) {
			if (onGround) {
				if (jumpTimer >= jumpCooldownTime) {
					Jump ();
				}
			}
		}
	}
	public void SetxInput(float f){
		xInput = f;
	}
	public void SetyInput(float f){
		yInput = f;
	}

	public bool IsGrounded(){
		if (Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - yOffset), new Vector2(boxCastWidth, .01f), 0.0f, Vector2.down, boxCastDistance)){
			return true;
		}
		else{
			return false;
		}
	}

	public void Jump(){
		rigi.velocity = new Vector2 (xInput * horizontalSpeed, jumpVelocity);
		ResetTimer ();
	}
	public void ResetTimer(){
		jumpTimer = 0.0f;
	}

}
