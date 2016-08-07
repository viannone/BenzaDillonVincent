using UnityEngine;
using System.Collections;

public class SimpleDestroyIfTouched : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D c){
		Transform t = c.transform;
		while(t.parent != null){
			t = t.parent;
		}
		if (t.GetComponent<DeathScript> () != null) {
			t.GetComponent<DeathScript> ().PlayerDeath ();
		}
		GameObject.Destroy(t.gameObject);
	}
}
