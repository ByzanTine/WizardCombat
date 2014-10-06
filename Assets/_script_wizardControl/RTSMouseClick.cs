using UnityEngine;
using System.Collections;
// NOTIC: Dependency on Itween
public class RTSMouseClick : MonoBehaviour {
	// public float movingSpeed = 0.5f;
	// public ParticleSystem mouseEffect; 
	public LayerMask collideLayer; // Only collide with the colliders in this layer

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Use Raycast to find the point mouse clicked
			if (Physics.Raycast (ray,out hit,Mathf.Infinity, collideLayer)) {
				// Debug.DrawLine(ray.origin, hit.point,Color.blue,10);
				// Instantiate(mouseEffect, hit.point, Quaternion.identity);
				// Hashtable ht = new Hashtable();
				// ht.Add("position", hit.point);
				// ht.Add("speed", movingSpeed);

				// iTween.MoveTo(gameObject, ht);
				// MovableUnit moveU = gameObject.GetComponent<MovableUnit> ();
				// moveU.MoveTo(hit.point);
				NavMeshAgent navAgent = gameObject.GetComponent<NavMeshAgent>();
				navAgent.SetDestination(hit.point);

				// LogMineobject(hitObject);


			}
			
		}
	}


}
