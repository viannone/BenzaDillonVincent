using UnityEngine;
using System.Collections;

public class Revolver : MonoBehaviour {
	public SpriteRenderer[] spriteRenderers = new SpriteRenderer[3];
	public Sprite[] powers = new Sprite[8];
	public int currentRotation = 0;
	public int currentPower123 = 1;
	public int speed;
	public bool revolutionRunning = false;
	Transform dummy1;
	Transform dummy2;

	void Start(){
		dummy1 = new GameObject ().transform;
		dummy2 = new GameObject().transform;
	}

	public void SetSprite(int renderer, int power){
		spriteRenderers [renderer].sprite = powers [power];
	}

	public void Revolve(){
		if (!revolutionRunning) {
			StartCoroutine ("Revolution");
		}
	}
	public IEnumerator Revolution(){
		revolutionRunning = true;
		Debug.Log ("I got started");
			dummy1.rotation = transform.rotation;
			dummy2.rotation = transform.rotation;
		Debug.Log (dummy2.rotation.eulerAngles);
			dummy2.Rotate(new Vector3 (120, 120, 120));
		Debug.Log (dummy2.rotation.eulerAngles);
			currentPower123++;
			if (currentPower123 > 3) {
				currentPower123 = 1;
			}
			while (true) {
				transform.rotation = Quaternion.Lerp(dummy1.rotation, dummy2.rotation, Time.deltaTime * speed);
				yield return null;
				if(transform.rotation == dummy2.rotation){
				revolutionRunning = false;
					break;
				}
			}
		}
}
