using UnityEngine;
using System.Collections;

public class PursueUsingPaths : MonoBehaviour {
	//our ultimate goal
	public Transform ultimateTarget;
	//our current goal
	public Transform subDestination;

	public GameObject[] nodes;

	public ArtificalIntelligenceBrain goToScript;

	void Start(){
		nodes = GameObject.FindGameObjectsWithTag ("Node");
	}
	// Update is called once per frame
	void FixedUpdate () {
		subDestination = GetClosestNodeToTarget();
		UpdateDestination(FindPathToUltimateTarget(subDestination));
		
	}

	//Step1 Get closest node to target
	public Transform GetClosestNodeToTarget(){
		Transform tempNode = nodes[0].transform;
		for(int i = 1; i < nodes.Length; i++){
			if ((tempNode.position - ultimateTarget.position).sqrMagnitude > (nodes[i].transform.position - ultimateTarget.position).sqrMagnitude){
				tempNode = nodes[i].transform;
			}
		}return tempNode;
	}
	public Transform FindPathToUltimateTarget(Transform destination){
		if ((ultimateTarget.position - transform.position).sqrMagnitude < (destination.position - transform.position).sqrMagnitude) {//TODO: Add a line-of-sight requirement
			subDestination = ultimateTarget;
		} return subDestination;
	}
	public void UpdateDestination(Transform t){
		goToScript.destination = t; //TODO: USE GETTERS AND SETTERS
	}
}
