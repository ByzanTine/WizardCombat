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
		int textureIndex = (int)wizard.magicState <= 2 ? (int)wizard.magicState : 0;

		Cursor.SetCursor(cursorTexture[textureIndex], Vector2.zero, CursorMode.Auto);

	}
}
