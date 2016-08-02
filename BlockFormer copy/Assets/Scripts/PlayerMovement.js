#pragma strict
var speed : float;
var movex : float;
var movey : float;
var rigi : Rigidbody2D;
var jumpReset : float;
var jumpVel : float;
var ladderVel : float;

//for Debug purposes only so we can view stat via inspector
var onGround : boolean;
var onLadder : boolean;

rigi = GetComponent.<Rigidbody2D>();
jumpReset = 0.0f;


function FixedUpdate () {
	jumpReset = jumpReset + Time.deltaTime;
	rigi.velocity = new Vector2 (movex * speed, rigi.velocity.y);

	if(IsGrounded()){//if you're on the ground
		if (movey > 0 && jumpReset >= .75){
			rigi.velocity = new Vector2 (movex * speed, jumpVel);
			jumpReset = 0;
			}
	}else if(onLadder){//if you're on a ladder
		rigi.velocity = new Vector2 (movex * speed, ladderVel * movey);
	}
}


function IsGrounded(){
	if (Physics2D.BoxCast(Vector2(transform.position.x, transform.position.y - 1.05), Vector2(.09f,.01f), 0.0f, Vector2(0, -1),.01f)){
		onGround  = true;
		return true;
	}
	else{
		onGround = false;
		return false;
	}
}

function SetOnLadder(b : boolean){
	onLadder = b;
	if (b == true){
		SetKinematicOn();
	}else if (b == false){
		SetKinematicOff();
	}
}

function SetKinematicOn(){
	rigi.isKinematic = true;
}

function SetKinematicOff(){
	rigi.isKinematic = false;
}


function SetMovementX(f : float){
	movex = f;
}

function SetMovementY(f : float){
	movey = f;
}