using UnityEngine;
using System.Collections;

public class AIWizard : Wizard {

	public enum AIWizardstate{
		Patrol,
		Dodge,
		Attack
	};
	public AIWizardstate aiState = AIWizardstate.Patrol;
	// Need the wall for the center and boundary
	private GameObject wall;

	private NavMeshAgent navAgent;
	private WizardAttackMeans attackmMeans;
	// It depends how catious the AI is, for far around the magma
	[Range(0,1)]
	private float awayFactor = 0.8f;
	// Attack Control

	public Vector3 target;

	void Start(){

		wall = GameObject.FindGameObjectWithTag(TagList.Wall);
		navAgent = gameObject.GetComponent<NavMeshAgent> ();
		attackmMeans = gameObject.GetComponent<WizardAttackMeans> ();

	}
	void Update(){
		if (aiState == AIWizardstate.Patrol){
			// 
			doPatrol();
		}
		else if (aiState == AIWizardstate.Dodge){
			doDodge ();
		}
		else if (aiState == AIWizardstate.Attack){
			// 
			doAttack();
		}
	}

	void doPatrol (){
		// Level of AI:
		// If is outside the bound, goes to the center
		// If inside, walk to a random direction decided using raycast
		// If a fireball comes, dodge
		// If notice sombody, then change the state to attack

		// Inside First
		if (standState == WizardStandState.OnDanger) {
			//move inside
			if (navAgent.velocity.magnitude == 0.0f){
				navAgent.SetDestination(wall.collider.bounds.center);
				Debug.Log("AI is moving to the center to avoid Danger");
			}


		}

		else if (standState == WizardStandState.OnSafe){
			//roam
			if (navAgent.velocity.magnitude == 0.0f){

				Vector3 direction = new Vector3(
					Random.Range(-1.0f, 1.0f), 
					0.0f,
					Random.Range(-1.0f, 1.0f) 
					);

				RaycastHit hitinfo;
				
				Ray AIdirectionRay = new Ray (transform.position, direction);
				Debug.DrawRay(transform.position,direction);
				if(wall.collider.Raycast(AIdirectionRay, out hitinfo, Mathf.Infinity)){
					Vector3 outVector = (hitinfo.point - transform.position);
					Vector3 destination = awayFactor * outVector + transform.position;

					navAgent.SetDestination(destination);
					
				}
				Debug.Log("AI is going around");
			}
			// If there is an emeny in cone sight, then change to attack mode

			
		}





	}
	void doDodge (){
		// Only dodge if a fireball is really close
		// Go in a perpendicular direction 
	}
	void doAttack (){
		//Hold Still
		navAgent.SetDestination(transform.position);
		// A FATAL BUG: the fireball will collide the detect collider
		// Now move the detection collider into the child
		Debug.Log("AI: Attack now!");
		// StartCoroutine(attackmMeans.Attack(SpellDB.AttackID.fireball, target));

		//Stay for a while

		aiState = AIWizard.AIWizardstate.Patrol;
	}


}
