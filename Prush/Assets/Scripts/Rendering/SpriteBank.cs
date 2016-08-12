using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpriteBank : MonoBehaviour {
	public List<Sprite> sprites;

	public bool lastSpriteTerminal;
	public bool goToNextSpriteSequence;
	public float secondsToSpriteChange;
	public SpriteManager manager;
	public SpriteBank nextSpriteSequence;
	public SpriteRenderer spriteRenderer;
	public int currentSprite;

	void Start(){
		spriteRenderer = transform.GetComponentInParent<SpriteRenderer> ();
		currentSprite = 0;
	}

	public IEnumerator IterateThroughSprites(){
		float timer = 0.0f;
		while (true) {
			timer += Time.deltaTime;
			if (timer >= secondsToSpriteChange) {
				timer = 0.0f;
				currentSprite++;
				if(currentSprite == sprites.Count){
					if (lastSpriteTerminal == true) {
						currentSprite--;
						spriteRenderer.sprite = sprites [currentSprite];
						break;
					} else if (goToNextSpriteSequence == true) {
						manager.ChangeSprites (nextSpriteSequence);
					}else {
						currentSprite = 0;
					}
				}
				spriteRenderer.sprite = sprites [currentSprite];
			}yield return null;
		}
	}
}
