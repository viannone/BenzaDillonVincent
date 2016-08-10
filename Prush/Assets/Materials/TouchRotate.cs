using UnityEngine;
using System.Collections;

public class TouchRotate : MonoBehaviour {
	private int amount = 0;
	private float cooldown = 0.0f;
	void OnCollisionEnter2D(Collision2D c){
		cooldown += Time.deltaTime;
		if (cooldown >= 1) {
			amount += 90;
			if (amount >= 360) {
				amount = amount - 360;
			} else if (amount < 0) {
				amount = (amount + 360);
			}
			c.gameObject.GetComponent<RotateHans> ().RotateTo (amount);
			cooldown = 0;
		}
	}
}
