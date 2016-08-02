using UnityEngine;
using System.Collections;

public class PointCameraAtMe : MonoBehaviour {

	public void Start(){
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<SimpleCameraFollow>().SetTarget(this.transform);
	}
}
