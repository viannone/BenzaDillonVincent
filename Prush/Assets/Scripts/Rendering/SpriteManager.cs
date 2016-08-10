using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour {
	public SpriteBankBank spriteBankBank;
	public SpriteBank spriteBank;
	public SpriteRenderer spriteRenderer;
	public float secondsToSpriteChange;

	void Start(){
		spriteBankBank = GetComponentInChildren<SpriteBankBank> ();
		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
	}

	public void SetSprites(int i){
		StopCoroutine("IterateThroughSprites");
		spriteBank = spriteBankBank.spriteBanks[i];
		if(spriteBank.sprites.Count == 1){
			spriteRenderer.sprite = spriteBank.sprites[0];
		}else{
			StartCoroutine("IterateThroughSprites");
		}
	}
	public IEnumerator IterateThroughSprites(){
		int currentSprite = 0;
		float timer = 0.0f;
		while (true) {
			timer += Time.deltaTime;
			if (timer >= secondsToSpriteChange) {
				timer = 0.0f;
				currentSprite++;
				if(currentSprite == spriteBank.sprites.Count){
					if (spriteBank.lastSpriteTerminal == true) {
						currentSprite--;
						spriteRenderer.sprite = spriteBank.sprites [currentSprite];
						break;
					} else {
						currentSprite = 0;
					}
				}
				spriteRenderer.sprite = spriteBank.sprites [currentSprite];
			}yield return null;
		}
	}


}
