using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PursueUsingPaths : MonoBehaviour {
	//our ultimate goal
	public Transform ultimateTarget;
	//our current goal
	public Transform currentDestination;
	public Transform closestNodeToYou;
	public Transform closestNodeToTarget;
	public Transform currentNode;
	public GameObject[] nodes;

	public ArtificalIntelligenceBrain goToScript;

	public int counter;
	void Start(){
		counter = 1;
		nodes = GameObject.FindGameObjectsWithTag ("Node");
		currentNode = GetClosestNodeToYou();
		StartCoroutine("FindPathToUltimateTarget", ultimateTarget);//changes Destination variable
	}
	//Step1 Get closest node to target
	public Transform GetClosestNodeToTarget(){
		Transform tempNode = nodes[0].transform; 
		int t = 0;
		while(!CheckLOS(tempNode, ultimateTarget)){
			t++;
			tempNode = nodes[t].transform;
		}
		for(int i = 1; i < nodes.Length; i++){
				if ((tempNode.position - ultimateTarget.position).sqrMagnitude > (nodes[i].transform.position - ultimateTarget.position).sqrMagnitude && CheckLOS(nodes[i].transform, ultimateTarget)){
					tempNode = nodes[i].transform;
			}
		}return tempNode;
	}

	public Transform GetClosestNodeToYou(){//NEEDS LINE OF SIGHT
		Transform curr = nodes [0].transform;
		int t = 0;
		while(!CheckLOS(curr, transform)){
				t++;
				curr = nodes[t].transform;
			}
		for (int i = 1; i < nodes.Length; i++) {
			if ((curr.position - transform.position).sqrMagnitude > (nodes [i].transform.position - transform.position).sqrMagnitude && CheckLOS(transform, nodes[i].transform)){
				curr = nodes [i].transform;
			}
		}
		return curr;
	}
	public bool CheckLOS(Transform a, Transform b){
			RaycastHit2D r = Physics2D.Linecast(a.position,b.position);
					if(r.collider == null){
						return true;
					}else{
						return false;
					}
	}

	public IEnumerator FindPathToUltimateTarget(Transform destination){
		while (true) {
			//Step1:
			closestNodeToYou = GetClosestNodeToYou ();
			//Step2:
			closestNodeToTarget = GetClosestNodeToTarget ();
			if (closestNodeToTarget == closestNodeToYou) {
				currentDestination = ultimateTarget;
			}
			//if you are closer to your target than the node is
			else if ((ultimateTarget.position - transform.position).sqrMagnitude < (closestNodeToTarget.position - ultimateTarget.position).sqrMagnitude){//TODO: Add a line-of-sight requirement
				//then set the destination to your ultimate target
				currentDestination = ultimateTarget;
			} else {
				currentDestination = closestNodeToYou;
				//Step 3
				//create a path from the destination node to the node closest to you by finding the next closest node in the sequence
				List<Transform> nodeGroup = new List<Transform> ();
				List<Transform> nextNodeGroup = new List<Transform> ();
				List<Transform> subNodes = new List<Transform> ();
				nodeGroup.Add (closestNodeToTarget);
				bool b = true;
				while (b) {


					for (int i = 0; i < nodeGroup.Count; i++) {
						currentNode = nodeGroup [i];
						subNodes.AddRange (currentNode.GetComponent<PathFindingNode> ().connectedNodes);
						for (int s = 0; s < subNodes.Count; s++) {
							if (subNodes [s] == closestNodeToYou && CheckLOS(transform, currentNode)) {
								currentDestination = currentNode;
								Debug.Log ("The subNode " + closestNodeToYou + " was the closest to you so your destination is " + currentDestination);
								b = false;
								break;
							}
							nextNodeGroup.Add (subNodes [s]);
						}
						if (b == false) {
							break;
						}
					}
					nodeGroup.Clear ();
					nodeGroup.AddRange (nextNodeGroup);
					nextNodeGroup.Clear ();
					if (b == false) {
						break;
					}
	
				}
					
			}
			UpdateDestination (currentDestination);
			yield return new WaitForSeconds(.5f);
		}

	}
	public void UpdateDestination(Transform t){
		goToScript.destination = t; //TODO: USE GETTERS AND SETTERS
	}
}
