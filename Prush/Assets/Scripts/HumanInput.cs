using UnityEngine;
using System.Collections;

public class HumanInput : MonoBehaviour {
	public NPCandPlayerMovement movementScript;

	void Start(){
		movementScript.SetxInput (Input.GetAxis ("Horizontal"));
		movementScript.SetyInput (Input.GetAxis ("Vertical"));
	}
	void FixedUpdate(){
		movementScript.SetxInput (Input.GetAxis ("Horizontal"));
		movementScript.SetyInput (Input.GetAxis ("Vertical"));
	}

}
