using UnityEngine;
using System.Collections;

public class AIWizardAnimator : MonoBehaviour {


	// Use this for initialization
	private Animator wizardAnimator;
	private NavMeshAgent navAgent;
	private AIWizard wizard;
	private WizardAttackMeans attackmMeans;
	// Update is called once per frame
	void Start (){
		wizardAnimator = gameObject.GetComponentInChildren<Animator> ();
		navAgent = gameObject.GetComponent<NavMeshAgent> ();
		wizard = gameObject.GetComponent <AIWizard> ();
		attackmMeans = gameObject.GetComponent<WizardAttackMeans> ();
		
	}
	void Update (){
		
		//Set Speed for animator
		wizardAnimator.SetFloat ("Speed", navAgent.velocity.magnitude);
		//Set Attack animation if needed
		if (!wizardAnimator.GetBool ("Attack") &&
		    !wizardAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
		    && wizard.aiState == AIWizard.AIWizardstate.Attack){

			StartCoroutine(attackmMeans.Attack(SpellDB.AttackID.fireball, wizard.target)); 
		}
		
		
	}
}
