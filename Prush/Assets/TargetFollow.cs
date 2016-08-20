using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour {

	public Vector2 targetPos;
	public Transform target;
	public Transform hansTarget;
	public int maxXDist;
	public int maxYDist;
	public float maxSpeed;
	public float targetTime;
	public bool bobY;
	public float yBobAmnt;
	public float yBobTime;
	Vector2 currentVel;
	Vector2 pos;

	public void SetTarget(Transform t){
		target = t;
	}
	public Vector2 FindDefaultTarget(){
		return hansTarget.position;
	}

	void Start(){
		StartCoroutine ("UpdateTargetPos");
		StartCoroutine ("ChaseTarget");
		if (bobY) {
			StartCoroutine ("AddYBob");
		}
	}

	public IEnumerator ChaseTarget(){
		while (true) {
			pos = transform.position;
			transform.position = Vector2.SmoothDamp (pos, targetPos, ref currentVel, targetTime, maxSpeed);
			yield return new WaitForFixedUpdate ();
		}
	}

	public IEnumerator UpdateTargetPos(){
		while (true) {
			if (target != null) {
				targetPos = target.position;
			} else if (hansTarget != null) {
				targetPos = hansTarget.position;
			} else {
				targetPos = transform.position;
			}
				
			yield return new WaitForEndOfFrame ();
		}
	}
	public IEnumerator AddYBob(){
		while (true) {
			float theta = Time.timeSinceLevelLoad / yBobTime;
			float distance = yBobAmnt * Mathf.Sin(theta);
			targetPos.y += distance;
			yield return new WaitForEndOfFrame ();
		}
	}
}
