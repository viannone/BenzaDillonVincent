using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCandPlayerMovement : MonoBehaviour {
	public Rigidbody2D rigi;
	public AttackScript attackScript;
	public int horizontalSpeed;
	public int jumpVelocity;
	public float jumpTimer;
	public float jumpCooldownTime;
	public float attackTimer;
	public float attackCooldownTime;
	public bool onGround;

	public float yOffset;

	public float xInput;//values b/w -1, 1
	public float yInput;
	public float attackInput;

	private float xVel;
	private float yVel;

	public float boxCastWidth;
	public float boxCastDistance;
	private int debugCounter;
	public int boxCastDirection;

	private Vector2 rigiY;

	public SpriteManager spriteManager;
	private SpriteRenderer spriteRenderer;
	private int currentSprites;


	public Transform lineCastPointA;
	public Transform lineCastPointB;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		ChangeSprites (0);
		//so you can jump immediately upon instantiation
		jumpTimer = jumpCooldownTime;
		spriteRenderer = spriteManager.spriteRenderer;
		boxCastDirection = -1;
	}

	void ChangeSprites(int i){
		if (i != currentSprites) {
			spriteManager.ChangeSpritesByInt (i);
			currentSprites = i;
		}
	}
	void Update(){
		onGround = IsGrounded ();
	}
	void FixedUpdate () {
		jumpTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
		//TODO: OPTIMIZE THIS BS
		//1.Take current globalVelocity
		//2.Translate that into local velocity
		Vector2 newVel = transform.InverseTransformDirection(rigi.velocity);
		//3.add whatever we need to add
		newVel = new Vector2 (xInput * horizontalSpeed, newVel.y);
		//4.translate that back to global velocity and apply
		rigi.velocity = transform.TransformDirection(newVel);


		//change sprites
		if (xInput > 0) {
			spriteRenderer.flipX = false;
		} else if (xInput < 0) {
			spriteRenderer.flipX = true;
		}


		if (!onGround) {
			ChangeSprites (2);
		}
		else if (onGround && Mathf.Abs(xInput) > 0) {
			ChangeSprites (1);
		} else if (onGround) {
			ChangeSprites (0);
			debugCounter++;
		}
		if (yInput > 0) {
			if (onGround) {
				if (jumpTimer >= jumpCooldownTime) {
					Jump ();
				}
			}
		}
		if (attackInput > 0) {
			attackTimer += Time.deltaTime;
			if (attackTimer > attackCooldownTime) {
				attackTimer = 0;
				Attack ();
			}
		}
	}
	public void SetxInput(float f){
		xInput = f;
	}
	public void SetyInput(float f){
		yInput = f;
	}
	public void SetAttackInput (float i){
		attackInput = i;
	}
	public void Attack(){
		attackScript.Attack ();
	}

	public bool IsGrounded(){
		if (Physics2D.Linecast(lineCastPointA.position, lineCastPointB.position)){
			return true;
		}
		else{
			return false;
		}
	}

	public void Jump(){
		rigi.velocity = transform.TransformDirection(new Vector2 (xInput * horizontalSpeed, jumpVelocity));
		ResetTimer ();
	}
	public void ResetTimer(){
		jumpTimer = 0.0f;
	}

}
