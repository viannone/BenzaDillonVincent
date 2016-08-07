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
	public float timeBetweenSnapShotsInSeconds;
	public float timer;
	public SnapShot[] snapShots = new SnapShot[amount];

	void Start(){
		t = transform;
		r = transform.GetComponent<Rigidbody2D> ();
		timer = 0.0f;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<TimeMaster> ().AddToList (this);
		StartCoroutine ("StartShootingSnapShots");
	}


	public IEnumerator StartShootingSnapShots(){
		while (true) {
			timer += Time.deltaTime;
			if (timer >= timeBetweenSnapShotsInSeconds) {
				if (index < amount ) {
					snapShots [index] = new SnapShot (t, r);
					index++;
					Debug.Log(snapShots[index - 1].GetPos() + " " + index);
				} else {
					ShiftBack (snapShots);
					snapShots [amount - 1] = new SnapShot (t, r);
				}
				timer = 0.0f;
			}yield return new WaitForSeconds (.025f);
		}
	}


		void ShiftBack(SnapShot[] s){
			for(int i = 0; i < s.Length - 1; i++){
				s[i] = s[i+1];
			}
	}
	public SnapShot Pull(int b){
		index--;
		return snapShots[index + 1];
	}

	public SnapShot[] GetSnapShots(){
		return snapShots;
	} 

}
