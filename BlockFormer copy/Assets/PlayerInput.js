#pragma strict

var MovementScript : PlayerMovement;

function FixedUpdate(){
	MovementScript.SetMovementX(Input.GetAxis ("Horizontal"));
	MovementScript.SetMovementY(Input.GetAxis ("Vertical"));
}