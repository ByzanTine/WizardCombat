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

	void Awake()
	{
		Clicker.Instance.onClickLeft += OnClickLeft;
	}

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
		    !wizardAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
		{
			if (wizard.magicState == Wizard.WizardMagicState.reflect)
			{

			}
		}
	}

	void OnClickLeft(Vector3 hitpoint)
	{
		if (!wizardAnimator.GetBool ("Attack") &&
		    !wizardAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
		    ) {
			//This Part is extendable for variable attack ways
			if (wizard.magicState == Wizard.WizardMagicState.fireBall){

				navAgent.SetDestination(
					Vector3.Normalize(hitpoint-transform.position) + transform.position
					);

				StartCoroutine(attackmMeans.Attack(hitpoint, WizardAttackMeans.AttackID.fireball));
			}
			else if(wizard.magicState == Wizard.WizardMagicState.meteor){

				navAgent.SetDestination(
					Vector3.Normalize(hitpoint-transform.position)+transform.position
					);
				
				StartCoroutine(attackmMeans.Attack(hitpoint, WizardAttackMeans.AttackID.meteor));
			}
			
		}
	}


}
