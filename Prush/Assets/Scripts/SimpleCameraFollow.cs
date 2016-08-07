using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {
	public Transform target;
	public int trackSpeed;
	public int cameraDistance;

	public void FixedUpdate(){
		try{
		transform.position = new Vector3(Mathf.Lerp (transform.position.x, target.position.x, trackSpeed * Time.deltaTime), Mathf.Lerp (transform.position.y, target.position.y, trackSpeed * Time.deltaTime), cameraDistance);
		}catch(MissingReferenceException e){
			Debug.Log ("No transform to follow right now. Please come back later.");
		}
	}

	public void SetTarget(Transform t){
		target = t;
	}
}
