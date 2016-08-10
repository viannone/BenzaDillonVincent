using UnityEngine;
using System.Collections;

public class GoToDestination : ArtificalIntelligenceBrain {


	public float acceleration;
	public float xInput;
	public float yInput;

	void Start(){
		movementScript = GetComponent<NPCandPlayerMovement> ();
	}

	void FixedUpdate(){
		ComputeXandYinputValues ();
		movementScript.SetxInput (xInput);
		movementScript.SetyInput (yInput);
	}
	void ComputeXandYinputValues(){
		int tpx = (int) transform.position.x;
		int tpy = (int) transform.position.x;
		if (destination != null) {
			tpx = (int)Mathf.Round (destination.position.x);
			tpy = (int)Mathf.Round (destination.position.y);
		}
		int px = (int) Mathf.Round(transform.position.x);
		int py = (int) Mathf.Round(transform.position.y);

		if (tpx > px) {
			xInput = Mathf.Lerp (xInput, 1, acceleration * Time.deltaTime);
		}else if (tpx < px) {
			xInput = Mathf.Lerp (xInput, -1, acceleration * Time.deltaTime);
		}else if (tpx == px) {
			xInput = Mathf.Lerp (xInput, 0, acceleration * Time.deltaTime);
		}
		if (tpy > py && Mathf.Abs(tpy-py) > Mathf.Abs(tpx-px)) {//if the distance upwards is greater than the distance horizontally
			yInput = Mathf.Lerp (yInput, 1, acceleration * Time.deltaTime);
		}else if (tpy < py) {
			yInput = Mathf.Lerp (yInput, -1, acceleration * Time.deltaTime);
		}else if (tpy == py) {
			yInput = Mathf.Lerp (yInput, 0, acceleration * Time.deltaTime);
		}
	}
}
