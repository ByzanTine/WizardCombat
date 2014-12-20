using UnityEngine;
using System.Collections;
// NOTIC: Dependency on Itween
public class RTSMouseClick : MonoBehaviour {

	// Awake
	private NavMeshAgent navAgent;
	void Awake ()
	{
		// Start the event listener
		Clicker.Instance.OnClickRight += OnClickRight;
	}

	void Start ()
	{
		navAgent = gameObject.GetComponent<NavMeshAgent>();
	}
	// The event that gets called
	void OnClickRight(Vector3 hitpoint)
	{
		navAgent.SetDestination(hitpoint);
	}



}
