using UnityEngine;
using System.Collections;

public class PlayerWizard : Wizard {


	void Update(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			magicState = WizardMagicState.fireBall;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			magicState = WizardMagicState.meteor;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			magicState = WizardMagicState.idle;
		}
		if (Input.GetMouseButton(0)){
			magicState = WizardMagicState.idle;
		}
		if (Input.GetMouseButtonDown (1)) {
			magicState = WizardMagicState.idle;
		}

	}

	// Draw a online health bar
	void OnGUI () {
		// Make a background box
		GUI.backgroundColor = Color.red;
		GUI.Box (new Rect(5,5,45,35),"Health");
		
		GUI.Box (new Rect(60,10,health,20),"");
		
	}

}
