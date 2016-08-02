#pragma strict
var teleportPair : Transform;
var teleportPairScript : Teleporter;

var teleportThis : Transform;
//debug


var cooldown : float;
var cooldownTime : float;

function Start(){
	cooldown = cooldownTime;
	teleportPairScript = teleportPair.GetComponent("Teleporter");
}

function FixedUpdate(){
	cooldown = cooldown + Time.deltaTime;
}

function OnTriggerEnter2D(collision : Collider2D){
	if(cooldown >= cooldownTime){
		Teleport(collision);
		ResetCoolDown();
		teleportPairScript.ResetCoolDown();
		}
}

function Teleport(collision : Collider2D){

	teleportThis = collision.transform;
	//Get the parent, if there is one
	while(teleportThis.parent != null){
		teleportThis = teleportThis.parent;
	}
	Instantiate(teleportThis, Vector3(teleportPair.position.x, teleportPair.position.y, 0), Quaternion.identity);
	Destroy(teleportThis.gameObject);
}

function ResetCoolDown(){
	cooldown = 0;
}