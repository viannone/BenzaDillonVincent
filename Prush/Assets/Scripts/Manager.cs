using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public void Death(Transform t){
		if(t.tag == "Player"){
			//TODO: ADD LIFE INDICATOR
			Debug.Log("You hella died");
		}
	}
}
