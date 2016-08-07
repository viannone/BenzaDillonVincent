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
			if (GetDestination() == null) {
			SetDestination (GameObject.FindGameObjectWithTag ("Player").transform);
			}
		}catch(Exception e){}
	}
	public void SetDestination(Transform t){
		brain.destination = t;
	}
	public Transform GetDestination(){
		if (brain.destination != null) {
			return brain.destination;
		}
		return null;
	}
}