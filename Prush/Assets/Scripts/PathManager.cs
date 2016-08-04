using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathManager : MonoBehaviour {
	public float maxJumpHeight;
	public static float _maxJumpHeight;

	void Start(){
		_maxJumpHeight = maxJumpHeight;
	}
}
