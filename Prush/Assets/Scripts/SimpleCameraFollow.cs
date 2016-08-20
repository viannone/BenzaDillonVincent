using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {
	public Transform target;
	Vector2 targetPos;
	Vector2 pos;
	Vector2 currentVel;
	public float maxSpeed;
	public float targetTime;
	public int cameraDistance;
	public bool bobY;
	public float yBobAmnt;
	public float yBobTime;
	public bool bobX;
	public float xBobAmnt;
	public float xBobTime;

	public void Start(){
		StartCoroutine ("UpdateTarget");
		StartCoroutine ("ChaseTarget");
	}

	public IEnumerator ChaseTarget(){
		while (true) {
			pos = transform.position;
			Vector2 intermediary = Vector2.SmoothDamp (pos, targetPos, ref currentVel, targetTime, maxSpeed);
			transform.position = new Vector3 (intermediary.x, intermediary.y, cameraDistance);
			yield return new WaitForFixedUpdate ();
		}
	}
	public IEnumerator UpdateTarget(){
		while (true) {
			if (target == null) {
				target = GameObject.FindGameObjectWithTag ("Player").transform;
			} 
			if (target != null) {
				targetPos = target.position;
			}
			if (bobY) {
				float theta = Time.timeSinceLevelLoad / yBobTime;
				float distance = yBobAmnt * Mathf.Sin(theta);
				targetPos.y += distance;
			}
			if (bobX) {
				float theta = Time.timeSinceLevelLoad / xBobTime;
				float distance = xBobAmnt * Mathf.Sin(theta);
				targetPos.x += distance;
			}
			yield return new WaitForEndOfFrame();
		}
	}
	public void SetTarget(Transform t){
		target = t;
	}
}
