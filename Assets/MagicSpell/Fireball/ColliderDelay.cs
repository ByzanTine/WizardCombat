using UnityEngine;
using System.Collections;

public class ColliderDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Collider> ().enabled = false;
		Invoke ("EnableCollider", 0.1f);//enable afte a second
	}
	
	// Update is called once per frame
	void EnableCollider () {
		gameObject.GetComponent<Collider> ().enabled = true;
	}
}
