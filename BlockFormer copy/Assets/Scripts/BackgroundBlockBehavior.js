var matList : Material[];
var randomInt : int;
function Start(){
	randomInt = Random.Range(0, matList.Length);
	gameObject.GetComponent.<Renderer>().material = matList[randomInt];
}

function FixedUpdate () {
	if(transform.position.y <= -15){
	transform.parent.GetComponent("GameStart").ReducebbCounter();
	Destroy (gameObject);
	}
}