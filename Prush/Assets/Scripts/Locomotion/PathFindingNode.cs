using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFindingNode : MonoBehaviour {

	GameObject[] allNodes;
	public Transform[] connectedNodes;

	void Awake(){
		GetAllNodes ();
		connectedNodes = new Transform[2];
		ConnectToClosestNodes (2);
	}

	void OnDrawGizmos() {
		//Draw colored lines b/w connected nodes
		Gizmos.color = Color.blue;
		Gizmos.DrawCube(transform.position, new Vector3(1,1,1));

		for (int i = 0; i < connectedNodes.Length; i++) {
			Gizmos.DrawLine (transform.position, connectedNodes [i].position);
			Gizmos.color = Color.blue;
		}
	}

	//Step1: Find all other nodes that can be connected
	public void GetAllNodes(){
		allNodes = GameObject.FindGameObjectsWithTag ("Node");
	}

	public void ConnectToClosestNodes(int numberOfNodesToConnectTo){
		GameObject g = new GameObject();
		connectedNodes[0] = g.transform;
		Transform currentNode = allNodes [0].transform;
		Vector2 him;
		Vector2 me = transform.position;
		if (currentNode == transform) {//if the first index is this node, then start with the next node
			currentNode = allNodes [1].transform;
		}
		int startingPoint = 0;
		for (int n = 1; n < (numberOfNodesToConnectTo + 1); n++) {
			for (int i = 0; i < allNodes.Length; i++) {
				if (allNodes [i] != gameObject && allNodes [i].transform.position != connectedNodes[0].position) {
					him = allNodes [i].transform.position;
					if ((him - me).sqrMagnitude < ((Vector2)currentNode.transform.position - me).sqrMagnitude) {
						if (!Physics.Linecast (him, me)) {
							currentNode = allNodes [i].transform;
							startingPoint = i;
						}
					}
				}
			}
			connectedNodes [n-1] = currentNode;
			currentNode = allNodes [0].transform;
		}
	}
}		