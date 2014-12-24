using UnityEngine;
using System.Collections;

public class EffectLink : MonoBehaviour {
	public GameObject visualEffect;
	// Use this for initialization
	void Start () {
		GameObject gb = Instantiate (visualEffect, transform.position, transform.rotation) as GameObject;
		gb.transform.parent = gameObject.transform;
	}	
	

}
