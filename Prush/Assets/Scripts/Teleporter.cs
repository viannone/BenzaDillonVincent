using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public Teleporter targetTeleporter;
	public int coolDown;
	public float coolDownTimer;
	private SpriteRenderer sp;
	private SpriteBank sb;
	private bool teleportReady;
	private TimeMaster tm;


	public void Start(){
		SetTeleportReady (true);
		coolDownTimer = coolDown;
		sp = GetComponentInChildren<SpriteRenderer> ();
		sb = GetComponentInChildren<SpriteBank> ();
		tm = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<TimeMaster>();
		tm.teleporters.Add (this);
	}

	public void OnTriggerEnter2D(Collider2D c){
		if (GetTeleportReady()) {
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
		t.position = targetTeleporter.transform.position;
	}
	public void ResetCooldown(){
		GetComponent<BoxCollider2D> ().enabled = false;
		coolDownTimer = 0.0f;
		sp.sprite = sb.sprites [1];
		SetTeleportReady (false);
		StartCoroutine("CoolDown");
	}
	public IEnumerator CoolDown(){
		while (GetTeleportReady() == false) {
			coolDownTimer += Time.deltaTime;
			if (coolDownTimer >= coolDown) {
				SetTeleportReady (true);
				sp.sprite = sb.sprites [0];
			}
			yield return null;
		}
	}
	public bool GetTeleportReady(){
					return teleportReady;
				}

	public void SetTeleportReady(bool b){
		teleportReady = b;
		GetComponent<BoxCollider2D> ().enabled = true;
	}

}
