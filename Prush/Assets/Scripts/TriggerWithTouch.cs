using UnityEngine;
using System.Collections;

public class TriggerWithTouch : MonoBehaviour {
	public TriggerableObject target;

	void OnTriggerEnter2D(){
		target.Activate();
	}
}
