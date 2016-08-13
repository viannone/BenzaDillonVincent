using UnityEngine;
using System.Collections;

public class TouchRotate : MonoBehaviour {
	public int rotation = 0;
	public static float _cooldown = 0.0f;

	void Update(){
		_cooldown += Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D c){
		RotateHans r = c.gameObject.GetComponent<RotateHans> ();
		if (r != null && r.enabled == true) {
			if (_cooldown >= 1.0f) {
				rotation = (int) r.transform.rotation.eulerAngles.z + 90;
				if (rotation >= 360) {
					rotation -= 360;
				} else if (rotation < 0) {
					rotation += 360;
				}
				r.RotateTo (rotation);
				Debug.Log ("Rotate Hans to: " + rotation);
				_cooldown = 0.0f;
			}
		}
	}
}
