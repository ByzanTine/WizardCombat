using UnityEngine;
using System.Collections;

public class WizardCursorEffect : MonoBehaviour {
	public Texture2D[] cursorTexture;

	public GameObject target; // Prefab
	public bool targetCreated = false;

	private GameObject curTarget;

	private Wizard wizard;
	private LayerMask collideLayer;

	void Start(){
		wizard = gameObject.GetComponent<Wizard> ();
		collideLayer = gameObject.GetComponent<RTSMouseClick> ().collideLayer;

	}
	void OnGUI(){

		Cursor.SetCursor(cursorTexture[(int)wizard.magicState], Vector2.zero, CursorMode.Auto);

	}
	void Update(){
		//Draw a Target on the ground if magicState is Fireball/Meteor
		if (wizard.magicState == Wizard.WizardMagicState.fireBall&&!targetCreated) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Use Raycast to find the point mouse clicked
			if (Physics.Raycast (ray,out hit,Mathf.Infinity, collideLayer)) {
				// Debug.DrawLine(ray.origin, hit.point,Color.red,10);
				// Sometimes, it will need a target to clearly show the place of it throw.
				curTarget = Instantiate(target, hit.point, Quaternion.identity) as GameObject;
				targetCreated = true;
				// Debug.Log (mouseEffect);
				
				
			}
		}
		else if (wizard.magicState == Wizard.WizardMagicState.idle && targetCreated){
			targetCreated = false;
			Destroy(curTarget);
		}
	}
}
