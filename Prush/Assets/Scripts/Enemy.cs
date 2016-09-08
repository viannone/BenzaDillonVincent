using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public TargetSelect t;
	// Use this for initialization
	void Start () {
		t = GameObject.FindGameObjectWithTag ("Prush").GetComponent <TargetSelect>();
		t.AddEnemyToList (this);
	}
}
