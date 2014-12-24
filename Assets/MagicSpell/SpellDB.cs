using UnityEngine;
using System.Collections;

public class SpellDB : MonoBehaviour {
	// TODO scale this up!
	// NOTICE: Still has a coupling with the WizardState
	public enum AttackID{
		fireball,
		iceball,
		meteor,
		reflect
	};

	static public string[] attackIDnames = {"fireball", "iceball", "meteor", "reflect"};

	public GameObject fireball_;
	public GameObject iceball_;
	public GameObject meteor_;
	public GameObject reflector_;


	static public GameObject fireball;
	static public GameObject iceball;
	static public GameObject meteor;
	static public GameObject reflector;
	void Awake()
	{
		Debug.Log("INIT: Create Reference to Spells");
		fireball = fireball_;
		iceball = iceball_;
		meteor = meteor_;
		reflector = reflector_;

	}
}
