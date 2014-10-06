using UnityEngine;
using System.Collections;

public class OntriggerAttack : MonoBehaviour {

	private AIWizard aiwizard;
	void Start() {
		aiwizard = gameObject.GetComponentInParent<AIWizard> ();
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == TagList.Player){
			Debug.Log ("Enemy Inside");
			//TODO calculate the angle 
			aiwizard.aiState = AIWizard.AIWizardstate.Attack;
			//Assign Target
			aiwizard.target = other.transform.position;
			Debug.DrawLine(transform.position, aiwizard.target, Color.red, 10.0f);
		}
	}
}
