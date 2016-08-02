#pragma strict
import UnityEngine.SceneManagement;
var backgroundBlock : Transform;
var bbcounter : int;
var time : float;

function Start () {
bbcounter = 0;
}

function FixedUpdate(){
checkBlocks();
updateTime();
}

function ReducebbCounter(){
bbcounter--;
}

function checkBlocks(){
	if (bbcounter < 20){
		if(time >= .1){
		InstantiateBlock();
		time = 0f;
		}
	}
}

function InstantiateBlock(){
		var i = Instantiate(backgroundBlock, Vector3((Random.value * 30) - 15, (Random.value * 10) + 15, (Random.value * 5) + 10), Quaternion.identity);
		i.transform.SetParent(this.transform);
		bbcounter++;
	}
function updateTime(){
time += Time.deltaTime;
}

function LoadLevel1(){
	 SceneManager.LoadScene("Level1") ;
}
function LoadTutorial(){
	 SceneManager.LoadScene("Tutorial") ;
}
function LoadOptions(){
	 SceneManager.LoadScene("Options") ;
}