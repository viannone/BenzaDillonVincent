using UnityEngine;
using System.Collections;

public class HumanInput : MonoBehaviour {
	public NPCandPlayerMovement movementScript;

	void Start(){
		movementScript = GetComponent<NPCandPlayerMovement> ();
		movementScript.SetxInput (Input.GetAxis ("Horizontal"));
		movementScript.SetyInput (Input.GetAxis ("Vertical"));
		movementScript.SetAttackInput (Input.GetAxis ("Attack"));
	}
	void FixedUpdate(){
		movementScript.SetxInput (Input.GetAxis ("Horizontal"));
		movementScript.SetyInput (Input.GetAxis ("Vertical"));
		movementScript.SetAttackInput (Input.GetAxis ("Attack"));
	}

}
