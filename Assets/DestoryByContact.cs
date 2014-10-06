using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

	// Use this for initialization
	public GameObject explosion;
	public GameObject playerExplosion;
	public int gameScore;


	void Start ()
	{


	}
	void OnTriggerEnter (Collider other) {
		Debug.Log (other.tag);
//		if (other.tag == "Boundary" || other.tag =="Enemy") {
//			return;
//		}
//		if(explosion != null)
//			Instantiate (explosion, transform.position, transform.rotation);

	}
	
	// Update is called once per frame

}
