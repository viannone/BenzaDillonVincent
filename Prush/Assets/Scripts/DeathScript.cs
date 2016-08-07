using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

	public Manager m;

	void Start(){
		m = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Manager> ();
	}
	public void PlayerDeath(){
		m.Death (this.transform);
	}
}
