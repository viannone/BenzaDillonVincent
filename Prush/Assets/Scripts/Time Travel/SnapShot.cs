using UnityEngine;
using System.Collections;

public class SnapShot{

		Transform t;
		Rigidbody2D r;

		Vector2 pos;
		Vector2 vel;

	public SnapShot(Transform a, Rigidbody2D b){
		t = a;
		r =  b;

		pos = (Vector2) t.position;
		vel = (Vector2) r.velocity;
		}
	public Vector2 GetPos(){
		return pos;
		}
	//TODO: Switch to Vector2 if possible
	public Vector2 GetVel(){
		return vel;
	}
}
