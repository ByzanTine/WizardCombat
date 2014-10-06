using UnityEngine;
using System.Collections;
/* This Script control the animation of the wizard 
 * Also since a bad coupling situation,
 * The animation is related to the release of the magic
 */

public class PlayerWizardAnimator : MonoBehaviour {


	public LayerMask collideLayer;
	// Use this for initialization
	private Animator wizardAnimator;
	private NavMeshAgent navAgent;
	private Wizard wizard;
	private WizardAttackMeans attackmMeans;
	// Update is called once per frame
	void Start (){
		wizardAnimator = gameObject.GetComponentInChildren<Animator> ();
		navAgent = gameObject.GetComponent<NavMeshAgent> ();
		wizard = gameObject.GetComponent <Wizard> ();
		attackmMeans = gameObject.GetComponent<WizardAttackMeans> ();

	}
	void Update (){

		wizardAnimator.SetFloat ("Speed", navAgent.velocity.magnitude);
		if (!wizardAnimator.GetBool ("Attack") &&
		    !wizardAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
		    Input.GetMouseButtonDown(0)) {
			//This Part is extendable for variable attack ways
			if (wizard.magicState == Wizard.WizardMagicState.fireBall){

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//Use Raycast to find the point mouse clicked
				if (Physics.Raycast (ray,out hit,Mathf.Infinity, collideLayer)) {
					Debug.DrawLine(ray.origin, hit.point,Color.blue,10);
					navAgent.SetDestination(
						Vector3.Normalize(hit.point-transform.position)+transform.position
						);
				}

				StartCoroutine(attackmMeans.Attack(hit.point, WizardAttackMeans.AttackID.fireball));
			}
			else if(wizard.magicState == Wizard.WizardMagicState.meteor){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//Use Raycast to find the point mouse clicked
				if (Physics.Raycast (ray,out hit,Mathf.Infinity, collideLayer)) {
					Debug.DrawLine(ray.origin, hit.point,Color.yellow,10);
					navAgent.SetDestination(
						Vector3.Normalize(hit.point-transform.position)+transform.position
						);
				}

				StartCoroutine(attackmMeans.Attack(hit.point, WizardAttackMeans.AttackID.meteor));
			}

		}


	}


}
