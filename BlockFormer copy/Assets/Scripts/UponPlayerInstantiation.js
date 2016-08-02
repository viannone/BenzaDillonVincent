#pragma strict

var gameMaster : GameObject;
var masterLevel1Script : MasterLevel1;

function Start () {
	gameMaster = GameObject.FindGameObjectWithTag("MainCamera");
	masterLevel1Script = gameMaster.GetComponent("MasterLevel1");
	masterLevel1Script.UpdatePlayer(this.transform);
}

