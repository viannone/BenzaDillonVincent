using UnityEngine;
using System.Collections;
using System;

public class ArtificialIntelligenceTargetPlayer : MonoBehaviour {

	public ArtificalIntelligenceBrain brain;

	void Start(){
		brain = GetComponent<ArtificalIntelligenceBrain> ();
	}

	void FixedUpdate(){
		try{
			if (GetTarget() == null) {
			SetTarget (GameObject.FindGameObjectWithTag ("Player").transform);
			}
		}catch(Exception e){}
	}
	public void SetTarget(Transform t){
		brain.target = t;
	}
	public Transform GetTarget(){
		if (brain.target != null) {
			return brain.target;
		}
		return null;
	}
}