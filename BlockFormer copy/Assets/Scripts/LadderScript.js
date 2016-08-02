#pragma strict
var playerScript : PlayerMovement;

function OnTriggerEnter2D(collision : Collider2D){

	playerScript = collision.gameObject.GetComponent("PlayerMovement");
	if(playerScript != null){
		playerScript.SetOnLadder(true);
	}
}
function OnTriggerExit2D(collision : Collider2D){

	playerScript = collision.gameObject.GetComponent("PlayerMovement");
	if(playerScript != null){
		playerScript.SetOnLadder(false);
	}
}