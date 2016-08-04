using UnityEngine;
using System.Collections;

public class SimpleDestroyIfTouched : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D c){
		Transform t = c.transform;
		while(t.parent != null){
			t = t.parent;
		}
		GameObject.Destroy(t.gameObject);
	}
}
