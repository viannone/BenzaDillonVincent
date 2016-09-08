using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	public bool pausedToggle;
	public bool buttonReset;
	public Canvas pauseMenu;

	public void Start(){
		pauseMenu.enabled = false;
		pausedToggle = false;
		buttonReset = true;
	}

	public void Update(){
		int val = (int) Input.GetAxisRaw ("Pause");
		if (val == 1 && pausedToggle == false && buttonReset == true) {
			pausedToggle = true;
			buttonReset = false;
			Pause ();
		} else if (val == 1 && pausedToggle == true && buttonReset == true) {
			pausedToggle = false;
			buttonReset = false;
			UnPause();
		} else if (val == 0) {
			buttonReset = true;
		}
	}

	void Pause(){
		Time.timeScale = 0;
		pauseMenu.enabled = true;
	}
	void UnPause(){
		Time.timeScale = 1;
		pauseMenu.enabled = false;
	}
}
