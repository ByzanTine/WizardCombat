using UnityEngine;
using System.Collections;

public class SpellDB : MonoBehaviour {
	public GameObject fireball_;
	public GameObject meteor_;

	static public GameObject fireball;
	static public GameObject meteor;

	void Awake()
	{
		Debug.Log("INIT: Create Reference to Spells");
		fireball = fireball_;
		meteor = meteor_;
	}
}
