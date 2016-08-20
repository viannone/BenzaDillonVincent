using UnityEngine;
using System.Collections;

public class MoveOnTrigger : TriggerableObject {
	public Vector2 pos;
	public Transform targetPos;
	public int destinationTimeInSeconds;

	void Start(){
		pos = transform.position;
	}

	public override void Activate(){
		StartCoroutine("LerpToDestination");
	}



	public IEnumerator LerpToDestination(){
		Vector2 vel = new Vector2 (0, 0);
		while (true) {
			pos = transform.position;
			transform.position = Vector2.SmoothDamp(pos, targetPos.position, ref vel, destinationTimeInSeconds); 
			if ((transform.position - targetPos.position).sqrMagnitude < 1){
				Debug.Log ("Broken");
				break;
			}
			yield return null;
		}
	}
}
