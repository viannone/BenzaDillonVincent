using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeMaster : MonoBehaviour {

	public List<TimeTravelController> timeTravelEnabledObjects = new List<TimeTravelController>();
	public List<Teleporter> teleporters = new List<Teleporter> ();
	public List<TimeCube> timeCubes = new List<TimeCube>();
	int serial = 0;
	public GameObject Hans;
	public SpriteManager spriteManager;

	public void FindHans(){
		Hans = GameObject.FindGameObjectWithTag ("Player");
		spriteManager = Hans.GetComponent<SpriteManager> ();
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
		SetTeleportersEnabled (false);
		for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
			TimeTravelController t = timeTravelEnabledObjects [i];
			DisableComponents (t);
			StartCoroutine ("IterateBackwardsThroughSnapShots", t);
		}
		//set Han's animation. No need to set it back; Hans will do it himself
		if (Hans == null) {
			FindHans ();
		}
		spriteManager.ChangeSpritesByInt (3);//3 is reserved for time effects
	}
	public void RestoreTime(){
		SetTeleportersEnabled (true);
		for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
			StopCoroutine ("IterateBackwardsThroughSnapShots");
			TimeTravelController t = timeTravelEnabledObjects [i];
			RestoreComponents (t);
		}
		if (Hans == null) {
			FindHans ();
		}
		spriteManager.ChangeSpritesByInt (0);//4 is stop time hold whatever
	}

	public void StopTime(){
		for (int i = 0; i < timeCubes.Count; i++) {
			timeCubes [i].StopTime ();
		}
		for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
			TimeTravelController t = timeTravelEnabledObjects [i];
			DisableComponents (t);
		//set Han's animation. No need to set it back; Hans will do it himself
		}
			if (Hans == null) {
				FindHans ();
			}
			spriteManager.ChangeSpritesByInt (4);//for stop time
	}
	public void UnStopTime(){
		for (int i = 0; i < timeCubes.Count; i++) {
			timeCubes [i].UnStopTime ();
		}
		for (int i = 0; i < timeTravelEnabledObjects.Count; i++) {
			TimeTravelController t = timeTravelEnabledObjects [i];
			RestoreComponents (t);
			//set Han's animation. No need to set it back; Hans will do it himself
		}
			if (Hans == null) {
				FindHans ();
			}
			spriteManager.ChangeSpritesByInt (0);
	}

	public void DisableComponents(TimeTravelController t){
		t.GetComponent<Rigidbody2D> ().isKinematic = true;
		t.StopSnappingShots ();
		ToggleThings(t, false);
	}

	public void ToggleThings(TimeTravelController t, bool b){
		for (int i = 0; i < t.thingsToTurnOff.Count; i++) {
			t.thingsToTurnOff [i].enabled = b;
		}
	}

	public void RestoreComponents(TimeTravelController t){
		t.StartSnappingShots ();
		t.GetComponent<Rigidbody2D> ().isKinematic = false;
		ToggleThings(t, true);
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
		bool timeStopped = false;
		float timeRewind;
		float timeStop;
		while (true) {
			timeRewind = Input.GetAxis ("TimeRewind");
			timeStop = Input.GetAxis ("TimeStop");

			if (timeRewind > 0 && timeStop == 0) {
				if (rewinding == false) {
					rewinding = true;
					RewindTime();
				}
			} else if (rewinding == true) {
					rewinding = false;
					RestoreTime();
			}

			if (timeStop > 0 && timeRewind == 0) {
				if (timeStopped == false) {
					timeStopped = true;
					StopTime();
				}
			} else if (timeStopped == true){
				timeStopped = false;
				UnStopTime();
			}
			yield return null;
		}
	}

	public void ApplySnapShot(TimeTravelController t, SnapShot s){
		t.transform.position = s.GetPos ();
	}

	public void SetTeleportersEnabled(bool b){
		for(int i = 0; i < teleporters.Count; i++){
			teleporters [i].GetComponent<Collider2D> ().enabled = b;
		}
	}
}
