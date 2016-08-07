using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeTravelController : MonoBehaviour {
	//these values HAVE to be public in order to be persistant when 
	Transform t;
	Rigidbody2D r;
	public static int amount = 50;
	public int index;
	//TODO: Remove velocity if unneccesary
	public static float _timeBetweenSnapShotsInSeconds;
	public float timer;
	public SnapShot[] snapShots = new SnapShot[amount];
	public int timeTravelSerialNumber; //these start with 1

	public List<MonoBehaviour> thingsToTurnOff;

	void Start(){
		_timeBetweenSnapShotsInSeconds = .05f;
		t = transform;
		r = transform.GetComponent<Rigidbody2D> ();
		timer = 0.0f;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<TimeMaster> ().AddToList (this);
		StartSnappingShots ();
	}


	public IEnumerator ShootSnapShots(){
		while (true) {
			timer += Time.deltaTime;
			if (timer >= _timeBetweenSnapShotsInSeconds) {
				if (index < amount) {
					snapShots [index] = new SnapShot (t, r);
					index++;
				} else {
					ShiftBack (snapShots);
					snapShots [amount - 1] = new SnapShot (t, r);
				}
				timer = 0.0f;
			}yield return new WaitForSeconds (.025f);
		}
	}
	public void StopSnappingShots(){
		index--;
		try{
		StopCoroutine ("ShootSnapShots");
		}catch(MissingReferenceException e){
			Debug.Log ("The timeControllerGotDestroyed, so it doesn't have to stop coroutine");
		}
	}
	public void StartSnappingShots(){
		StartCoroutine ("ShootSnapShots");
	}

		void ShiftBack(SnapShot[] s){
			for(int i = 0; i < s.Length - 1; i++){
				s[i] = s[i+1];
			}
	}
	public SnapShot GetSnapShot(int i){
		return snapShots [index];
		if (index > 0) {
			index--;
		}
	}

	public SnapShot[] GetSnapShots(){
		return snapShots;
	} 

}
