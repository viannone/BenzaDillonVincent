using UnityEngine;
using System.Collections;

public class RotateHans : MonoBehaviour {

	public Transform t;
	public Vector2 grav;
	public float gravConstant;
	public Vector2 newGrav;
	void Start(){
		t = gameObject.transform;
		grav = Physics2D.gravity;
		gravConstant = grav.y;
	}

		public void RotateTo(int eulerAngleZedAxis){
		t.rotation = Quaternion.Euler (0, 0, eulerAngleZedAxis);
		UpdateGravity((int) Mathf.Round(eulerAngleZedAxis));
		}

		public void UpdateGravity(int rotationAngle){
			if (rotationAngle == 90) {
				newGrav = new Vector2(-gravConstant, 0);
			Debug.Log ("Grav going right");
			}else if(rotationAngle == 180){
				newGrav = new Vector2(0, -gravConstant);
			Debug.Log ("Grav going up --- on a Tuesday");
			}else if(rotationAngle == 270){
				newGrav = new Vector2(gravConstant, 0);
			Debug.Log ("Grav going left");
			}else if(rotationAngle == 0){
				newGrav = new Vector2(0, gravConstant);
			Debug.Log ("Grav going down");
			}
		Debug.Log ("Incoming rotation angle " + rotationAngle);
		Debug.Log ("Hans's actual rotation " + t.rotation.eulerAngles.z);
		Physics2D.gravity = newGrav;
		}
		
}
