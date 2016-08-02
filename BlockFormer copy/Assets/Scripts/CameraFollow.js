#pragma strict
var target : Transform;
var cameraDampX : int;
var cameraDampY : int;

function Start () {
	transform.position.x = target.transform.position.x;
	transform.position.y = target.transform.position.y;
	transform.position.z = -10;
}

function FixedUpdate () {
	transform.position.x = Mathf.Lerp (transform.position.x, target.transform.position.x, cameraDampX * Time.deltaTime);
	transform.position.y = Mathf.Lerp (transform.position.y, target.transform.position.y, cameraDampY * Time.deltaTime);
	transform.position.z = - 10;
}

function SetTarget(t : Transform){
target = t;
}