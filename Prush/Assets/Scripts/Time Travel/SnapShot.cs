using UnityEngine;
using System.Collections;

public class SnapShot{

		Transform t;
		Rigidbody2D r;

		Vector2 pos;
		Vector2 vel;

	public SnapShot(Transform t, Rigidbody2D r){
			this.t = t;
			this.r = r;

		pos = (Vector2) t.position;
		vel = (Vector2) r.velocity;
		}
	public Vector2 GetPos(){
		return pos;
	}
	public Vector2 GetVel(){
		return vel;
	}
}
