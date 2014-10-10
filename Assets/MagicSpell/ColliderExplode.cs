using UnityEngine;
using System.Collections;

public class ColliderExplode : MonoBehaviour {
	public LayerMask overlapLayer;
	// Use this for initialization
	void Start () {
		
	

		Collider[] co = Physics.OverlapSphere(transform.position, 3.0f, overlapLayer);

		// TODO Identify if the collider is pushable(namely only players)
		Debug.Log ("meet objects: " + co.Length);
		foreach (Collider collider in co){
			if (collider.gameObject.tag == TagList.Player){

				collider.attachedRigidbody.AddExplosionForce(500.0f, transform.position, 0);
			}
		}
	}
}
