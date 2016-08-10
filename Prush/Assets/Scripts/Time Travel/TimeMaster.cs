using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeMaster : MonoBehaviour {

	public List<TimeTravelController> timeTravelEnabledObjects = new List<TimeTravelController>();
	int serial = 0;
	public GameObject Hans;

	public void FindHans(){
		Hans = GameObject.FindGameObjectWithTag ("Player");
	}

	public void AddToList(TimeTravelController t){
		//if it doesn't have a serial number, give it one
		if (t.timeTravelSerialNumber == 0) {
			timeTravelEnabledObjects.Add(t);
			serial++;
			t.timeTravelSerialNumber = serial;
		} else {//if it ALREADY has one
			timeTravelEnabledObjects[t.timeTravelSerialNumber -1] = t;//because serial numbers are 1 indexed and lists are zero indexed
		}
	}

	public void RewindTime(){
		for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
			DisableComponents (timeTravelEnabledObjects [i]);
			StartCoroutine ("IterateBackwardsThroughSnapShots", timeTravelEnabledObjects[i]);
		}
		//set Han's animation. No need to set it back; Hans will do it himself
		if (Hans == null) {
			FindHans ();
		}
		Hans.GetComponent<SpriteManager>().SetSprites(3);//3 is dedicated to time animations
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
		Collider2D c = t.transform.GetComponent<Collider2D> ();
		if(c != null){
			c.enabled = false;
		}
		for (int i = 0; i < t.thingsToTurnOff.Count; i++) {
			t.thingsToTurnOff [i].enabled = false;
		}
	}

	public void RestoreComponents(TimeTravelController t){
		t.StartSnappingShots ();
		t.transform.GetComponent<Rigidbody2D>().isKinematic = false;
		Collider2D c = t.transform.GetComponent<Collider2D> ();
		if(c != null){
			c.enabled = true;
		}
		for (int i = 0; i < t.thingsToTurnOff.Count; i++) {
			t.thingsToTurnOff [i].enabled = true;
		}
	}

	public IEnumerator IterateBackwardsThroughSnapShots(TimeTravelController t){
		float timer = 0.0f;
		int serialNumber = t.timeTravelSerialNumber;
		while (true) {
			if (t == null) {//if the object we're trying to find gets destroyed i.e. goes backwards through a teleporter
				Debug.Log("T is null, but that's ok; we'll get a new one");
				for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
					if (timeTravelEnabledObjects [i].timeTravelSerialNumber == serialNumber) {
						t = timeTravelEnabledObjects [i];
						break;
					}
				}
			}
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
			yield return null;
//			Debug.Log (t.index);
		}
	}
		public void SetToSnapShot(TimeTravelController t, int i){
			SnapShot s = t.GetSnapShot(i);
		if (t == null) {
			Debug.Log ("T is null and that's the problem");
		}
		if (s == null) {
			Debug.Log ("S is null and that's the problem");
		}
		ApplySnapShot (t, s);
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
			yield return null;
		}
	}

	public void ApplySnapShot(TimeTravelController t, SnapShot s){
		t.transform.position = s.GetPos ();
	}
}
