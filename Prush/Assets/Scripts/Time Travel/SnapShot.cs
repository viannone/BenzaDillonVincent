using UnityEngine;
using System.Collections;

public class SnapShot : ScriptableObject{

		Transform trans;
		Vector2 pos;

	public static SnapShot _CreateNewSnapShot(Transform t){
		SnapShot OhSnap = CreateInstance<SnapShot> ();
			OhSnap.trans = t;
			OhSnap.pos = t.position;

		return OhSnap;
	}

	public Vector2 GetPos(){
		return pos;
		}
}
