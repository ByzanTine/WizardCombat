using UnityEngine;
using System.Collections;

public class RandomMoving : MonoBehaviour {

	bool right = false;
	float time;
	NavMeshAgent navAgent;
	void Awake (){
		navAgent = gameObject.GetComponent<NavMeshAgent> ();
	}
	void FixedUpdate () {

		if (!right) {
			right = !right;
			StartCoroutine(GoSomeWhere());
		}


	}
	IEnumerator GoSomeWhere (){
		navAgent.SetDestination( new Vector3(Random.Range (0, 10), transform.position.y, Random.Range (0, 10)));
		yield return new WaitForSeconds (10.0f);
		right = !right;
	}
}
