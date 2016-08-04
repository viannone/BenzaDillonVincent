using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSpriteInstantiator: MonoBehaviour {
	SpriteRenderer sr;
	SpriteBank sb;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		sb = GetComponent<SpriteBank> ();
		sr.sprite = sb.sprites [Random.Range(0, sb.sprites.Count)];
	}

}
