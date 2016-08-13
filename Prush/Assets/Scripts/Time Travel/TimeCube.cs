using UnityEngine;
using System.Collections;

public class TimeCube : MonoBehaviour {

	public TimeMaster tm;
	public int speed;
	private Rigidbody2D rigi;
	private Vector2 velocity;

	public void Start(){
		rigi = GetComponent<Rigidbody2D> ();
		tm = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<TimeMaster> ();
		tm.timeCubes.Add (this);
		UnStopTime();
	}
		
	public virtual void StopTime(){
		velocity = new Vector2 (0, -speed);
	}
	public virtual void UnStopTime(){
		velocity = new Vector2 (0, speed);
	}
	public void Update(){
		rigi.velocity = velocity;
	}
}
