using UnityEngine;
using System.Collections;

public class ColliderExplode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	

		Collider[] co = Physics.OverlapSphere(transform.position, 1.0f);

		// TODO Identify if the collider is pushable(namely only players)

		foreach (Collider collider in co){
			if (collider.gameObject.tag == TagList.Player)
				collider.attachedRigidbody.AddExplosionForce(1000.0f, transform.position, 1.0f);

		}
	}
}
