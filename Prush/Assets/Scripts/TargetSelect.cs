using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetSelect : MonoBehaviour {

	public List<Enemy> enemies;
	public Transform closestTarget;
	public Transform hans;
	public Transform targetMarker;
	public int aggroWidth;
	public int aggroHeight;
	public int hoverHeight;
	public TargetFollow tf;

	void Awake(){
		enemies = new List<Enemy>();
	}
	public void AddEnemyToList(Enemy e){
		enemies.Add (e);
	}

	void Start(){
		closestTarget = null;
		StartCoroutine ("SetClosestTargetOrHans");
		StartCoroutine ("UpdateTargetMarker");
	}

	public void SetPrushTarget(Transform t){
			tf.SetTarget (t);
	}
	public IEnumerator SetClosestTargetOrHans(){
		while(true){
		for (int i = 0; i < enemies.Count; i++) {
			Vector2 enemyPos = enemies [i].transform.position;
			Vector2 hansPos = hans.transform.position;
				yield return null;
			if (Mathf.Abs (enemyPos.x - hansPos.x) <= aggroWidth) {
					if (Mathf.Abs (enemyPos.y - hansPos.y) <= aggroHeight) {
						yield return null;
					if (closestTarget != null) {
							if((enemyPos - hansPos).sqrMagnitude < ((Vector2) closestTarget.transform.position - hansPos).sqrMagnitude){
								closestTarget = enemies[i].transform;
						}
					} else {
						closestTarget = enemies [i].transform;
					}
				}
			}
		}
					if(closestTarget == null){
						closestTarget = hans;
					}
			UpdateTargetMarker ();
			yield return new WaitForSeconds(1.0f);
		}
	}
	public IEnumerator UpdateTargetMarker(){
		Vector2 pos = new Vector2 ();
		while (true) {
			if (closestTarget != null) {
				pos = closestTarget.position;
			}
			pos.y += hoverHeight;
			targetMarker.position = pos;
			SetPrushTarget (targetMarker);
			yield return new WaitForSeconds (.1f);
		}
	}
}