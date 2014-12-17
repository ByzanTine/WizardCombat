using UnityEngine;
using System.Collections;

public class WizardCursorEffect : MonoBehaviour {
	public Texture2D[] cursorTexture;

	private Wizard wizard;

	void Start(){
		wizard = gameObject.GetComponent<Wizard> ();
		// collideLayer = gameObject.GetComponent<RTSMouseClick> ().collideLayer;

	}
	void OnGUI(){

		Cursor.SetCursor(cursorTexture[(int)wizard.magicState], Vector2.zero, CursorMode.Auto);

	}
}
