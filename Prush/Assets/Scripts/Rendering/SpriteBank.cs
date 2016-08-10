using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpriteBank : MonoBehaviour {
	public List<Sprite> sprites;

	public bool lastSpriteTerminal;
	public bool goToNextSpriteSequence;
	public SpriteBank nextSpriteSequence;
}
