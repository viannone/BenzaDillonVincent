using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeMaster : MonoBehaviour {

	public List<TimeTravelController> timeTravelEnabledObjects = new List<TimeTravelController>();
	int serial = 0;
	public void AddToList(TimeTravelController t){
		//if it doesn't have a serial number, give it one
		if (t.timeTravelSerialNumber == 0) {
			serial++;
			t.timeTravelSerialNumber = serial;
			timeTravelEnabledObjects [serial - 1] = t;//because serial numbers are 1 indexed and lists are zero indexed
			Debug.Log ("My serial number is: " + t.timeTravelSerialNumber);
		} else {//if it ALREADY has one
			timeTravelEnabledObjects[t.timeTravelSerialNumber -1] = t;
			Debug.Log ("My serial number is: " + t.timeTravelSerialNumber);
		}
	}

	public void RewindTime(){
		for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
			Debug.Log (timeTravelEnabledObjects.Count);
			DisableComponents (timeTravelEnabledObjects [i]);
			StartCoroutine ("IterateBackwardsThroughSnapShots", timeTravelEnabledObjects[i]);
		}
	}
	public void RestoreTime(){
		for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
			StopCoroutine ("IterateBackwardsThroughSnapShots");
			RestoreComponents (timeTravelEnabledObjects [i]);
		}
	}

	public void DisableComponents(TimeTravelController t){
		t.StopSnappingShots ();
		t.transform.GetComponent<Rigidbody2D>().isKinematic = true;
		for (int i = 0; i < t.thingsToTurnOff.Count; i++) {
			t.thingsToTurnOff [i].enabled = false;
		}
	}

	public void RestoreComponents(TimeTravelController t){
		t.StartSnappingShots ();
		t.transform.GetComponent<Rigidbody2D>().isKinematic = false;
		for (int i = 0; i < t.thingsToTurnOff.Count; i++) {
			t.thingsToTurnOff [i].enabled = true;
		}
	}

	public IEnumerator IterateBackwardsThroughSnapShots(TimeTravelController t){
		float timer = 0.0f;
		while (true) {
			if (t.index > -1) {
				timer += Time.deltaTime;
				if (timer >= TimeTravelController._timeBetweenSnapShotsInSeconds) {
					timer = 0.0f;
					SetToSnapShot (t, t.index);
					if(t.index > 0){
						t.index--;
					}
				}
		
			}
			yield return new WaitForSeconds (.025f);
		}
	}
		public void SetToSnapShot(TimeTravelController t, int i){
			SnapShot s = t.GetSnapShot(i);
			t.transform.position = s.GetPos ();
			//TODO: ADD MORE!
		}
		public void Start(){
			StartCoroutine("CheckInput");
		}
		
	public IEnumerator CheckInput(){
		bool rewinding = false;
		while (true) {
			if (Input.GetAxis ("Time") > 0) {
				if (rewinding == false) {
					rewinding = true;
					RewindTime();
				}
			} else {
				if (rewinding == true) {
					rewinding = false;
					RestoreTime();
				}
			}
			yield return new WaitForSeconds (.25f);
		}
	}
}
