using UnityEngine;
using System.Collections;

public class RotateHans : MonoBehaviour {

	public Transform t;
	public Vector2 grav;
	public float gravConstant;
	void Start(){
		t = gameObject.transform;
		grav = Physics2D.gravity;
		gravConstant = grav.y;
	}

		public void RotateTo(int eulerAngleZedAxis){
		t.rotation = Quaternion.Euler (0, 0, eulerAngleZedAxis);
			UpdateGravity(eulerAngleZedAxis);
		}

		public void UpdateGravity(int rotationAngle){
			Vector2 newGrav = new Vector2 (0, 0);
		if (rotationAngle == 90) {
			newGrav = new Vector2(-gravConstant, 0);
		}else if(rotationAngle == 180){
			newGrav = new Vector2(0, -gravConstant);
			}else if(rotationAngle == 270){
			newGrav = new Vector2(gravConstant, 0);
			}else if(rotationAngle > 270 || rotationAngle <= 0){
			newGrav = new Vector2(0, gravConstant);
			}
		Physics2D.gravity = newGrav;
		Debug.Log (Physics2D.gravity);
		}
		
}
