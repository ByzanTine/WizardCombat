using UnityEngine;
using System.Collections;

public class DetectEnemies : MonoBehaviour {

	private AIWizard aiwizard;
	public LayerMask collideLayer;
	
	private bool shooting;
	void Start() {
		aiwizard = gameObject.GetComponentInParent<AIWizard> ();
		shooting = false;
	}
	void Update() {
		if (!shooting)
		{
			shooting = !shooting;

			StartCoroutine(CallAttack());

		}
	}

	IEnumerator CallAttack()
	{

		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.forward);
		
		//Use Raycast to find the point mouse clicked
		// Debug.DrawLine(transform.position, transform.position + transform.forward * 10);
		if (Physics.Raycast (ray,out hit,Mathf.Infinity, collideLayer)) {
			Debug.Log("Got You, be careful!");
			aiwizard.target  = hit.point;
			aiwizard.aiState = AIWizard.AIWizardstate.Attack;
			yield return new WaitForSeconds(1.0f);
			
		}
		shooting = !shooting;


	}	
}
