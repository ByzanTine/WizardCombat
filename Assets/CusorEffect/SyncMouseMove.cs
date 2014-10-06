using UnityEngine;
using System.Collections;

public class SyncMouseMove : MonoBehaviour {
	private GameObject player;
	private Wizard wizard;
	private WizardCursorEffect wizardCE;

	public LayerMask collideLayer;
	void Start() {
		player = GameObject.FindGameObjectWithTag (TagList.Player);
		wizard = player.GetComponent<Wizard> ();
		wizardCE = player.GetComponent<WizardCursorEffect> ();
	}

	// Update is called once per frame
	void Update () {
		if (wizard.magicState == Wizard.WizardMagicState.fireBall&&
		    wizardCE.targetCreated) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Use Raycast to find the point mouse clicked
			if (Physics.Raycast (ray,out hit,Mathf.Infinity, collideLayer)) {
				// Debug.DrawLine(ray.origin, hit.point,Color.red,10);
				// Sometimes, it will need a target to clearly show the place of it throw.
				gameObject.transform.position = hit.point;
				
				// Debug.Log (mouseEffect);
				
				
			}
		}
	}
}
