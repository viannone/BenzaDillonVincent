using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFindingNode : MonoBehaviour {

	GameObject[] allNodes;
	public List<Transform> connectedNodes;

	void Start(){
		GetAllNodes ();
		ConnectToNodes ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawCube(transform.position, new Vector3(1,1,1));

		for (int i = 0; i < connectedNodes.Count; i++) {
			if (Mathf.Abs(connectedNodes [i].position.y - transform.position.y) > PathManager._maxJumpHeight) {
				Gizmos.color = Color.red;
			}
			Gizmos.DrawLine (transform.position, connectedNodes [i].position);
			Gizmos.color = Color.blue;
		}
	}

	//Step1: Find all other nodes that can be connected
	public void GetAllNodes(){
		allNodes = GameObject.FindGameObjectsWithTag ("Node");
	}

	public void ConnectToNodes(){
		for(int i = 0; i < allNodes.Length; i++){
			if(!Physics2D.Linecast(transform.position, allNodes[i].transform.position)){
				connectedNodes.Add(allNodes[i].transform);
			}
		}
	}
}

