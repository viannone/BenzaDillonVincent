#pragma strict

var MovementScript : PlayerMovement;
var target : Transform;

var x : float;
var y : float;

var accelValue : float;

function FixedUpdate(){
	if(target == null){
		SetTarget(GameObject.FindWithTag("Player").transform);
	}
	//values between -1 and 1
	MoveTowardsTarget();
	MovementScript.SetMovementX(x);
	MovementScript.SetMovementY(y);
}

function SetTarget(t : Transform){
	target = t;
}

function SetX(i : int){
	x = Mathf.Lerp(x, i, accelValue * Time.deltaTime);
}
function SetY(i : int){
	y = i;
}

function MoveTowardsTarget(){
	var tpx : int = target.position.x;
	var tpy : int = target.position.y;

	var px : int = transform.position.x;
	var py : int = transform.position.y;
	if (tpx > px){
		SetX(1);
	}else if (tpx < px){
		SetX(-1);
	}else if (tpx == px){
		SetX(0);
	}

	if (tpy > py){
		SetY(1);
	}else if (tpy < py){
		SetY(-1);
	}else if (tpy == py){
		SetY(0);
	}
}