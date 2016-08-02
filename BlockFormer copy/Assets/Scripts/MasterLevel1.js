#pragma strict
var playerCharacter : Transform;
var cameraFollowScript : CameraFollow;

function UpdatePlayer(t : Transform){
	playerCharacter = t;
	UpdateCameraTarget(playerCharacter);
}
function UpdateCameraTarget(t : Transform){
cameraFollowScript.SetTarget(t);
}
