using UnityEngine;
using System.Collections;

public class HansAttack : AttackScript {
	public Revolver revolver;
	public void Start(){
		revolver = GameObject.FindGameObjectWithTag ("MainCamera").GetComponentInChildren<Revolver>();
	}
	public override void Attack(){
		Debug.Log ("I got called");
		revolver.Revolve ();
	}
}
