using UnityEngine;
using System.Collections;

public class WizardInsideArea : MonoBehaviour {

	// Use this for initialization

	private GameObject wall;
	private Wizard wizard;
	void Awake () {
		wall = GameObject.FindGameObjectWithTag("Wall");
		wizard = gameObject.GetComponent<Wizard> ();

	}
	
	// Determine the state of the wizard by it's location related to the stand-zone
	void FixedUpdate () {
		Vector3 center = wall.collider.bounds.center;
		Vector3 direction = center - transform.position;
		RaycastHit hitinfo;

		Ray CenterOutRay = new Ray (transform.position, direction);

		// Draw a Raycast from center to player 
		// If it collide the wall, then it's outside of area
		// Else it's inside
		if(wall.collider.Raycast(CenterOutRay, out hitinfo, direction.magnitude)){
			Debug.DrawLine(transform.position,hitinfo.point,Color.blue);
			// Change the stand state if outside
			// Will Casue Continously Damage
			wizard.standState = Wizard.WizardStandState.OnDanger;

		}
		else{
			wizard.standState = Wizard.WizardStandState.OnSafe;
		}

	}
}
