using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour {
	public SpriteBankBank spriteBankBank;
	public SpriteBank spriteBank;
	public SpriteRenderer spriteRenderer;

	void Start(){
		spriteBankBank = GetComponentInChildren<SpriteBankBank> ();
		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
	}

	public void ChangeSpritesByInt(int i){
		ChangeSprites(spriteBankBank.spriteBanks[i]);
	}
	public void ChangeSprites(SpriteBank sb){
		if (spriteBank != null) {
			spriteBank.StopCoroutine ("IterateThroughSprites");
			spriteBank.currentSprite = 0;
		}
		spriteBank = sb;
		spriteBank.manager = this;
		if(spriteBank.sprites.Count == 1){//if there's only one sprite in the bank, don't bother updating
			spriteRenderer.sprite = spriteBank.sprites[0];
		}else{
			spriteBank.StartCoroutine("IterateThroughSprites");
		}
	}


}
