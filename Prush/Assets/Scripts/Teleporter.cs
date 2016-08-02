using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public Teleporter targetTeleporter;
	public int coolDown;
	public float coolDownTimer;

	public void Start(){
		coolDownTimer = coolDown;
	}

	public void FixedUpdate(){
		coolDownTimer += Time.deltaTime;
	}

	public void OnTriggerEnter2D(Collider2D c){

		if (coolDownTimer >= coolDown) {
			Teleport (c);
			ResetCooldown ();
			targetTeleporter.ResetCooldown ();
		}
	}
	public void Teleport(Collider2D c){
		Transform t = c.transform;
		//if not the highest parent, find it
		while (t.parent != null) {
			t = t.parent;
		}
		Instantiate (t, targetTeleporter.transform.position, Quaternion.identity);
		GameObject.Destroy (t.gameObject);
	}
	public void ResetCooldown(){
		coolDownTimer = 0.0f;
	}
}
