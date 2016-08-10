using UnityEngine;
using System.Collections;

public class OnCollisionDisableKinematic : MonoBehaviour {
	public Rigidbody2D rigi;

	void Start(){
		rigi = gameObject.GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(){
		rigi.isKinematic = false;
	}
}
