using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WizardAttackMeans : MonoBehaviour {
	/*
	 * This part will be easily scaled 
	 */
	public enum AttackID{
		fireball,
		meteor,
		reflect
	};
	public string[] attackIDnames = {"fireball", "meteor", "reflect"};
	// Use this for initialization
	private Animator wizardAnimator;
	private MagicSpell magicSpell;
	private List<MagicSpell> magicPool;

	void Start () {
		int enumSize = System.Enum.GetValues (typeof(AttackID)).Length;
		Debug.Log ("INIT: Number of Spells a wizard can use: " + enumSize);
		magicPool = new List<MagicSpell>{new FireballSpell(), new MeteorSpell(), new ReflectSpell()};

		wizardAnimator = gameObject.GetComponentInChildren<Animator> ();
	}
	
	public IEnumerator Attack(Vector3 to, AttackID id){
		wizardAnimator.SetBool ("Attack", true);
		yield return new WaitForSeconds (1.0f);

		magicSpell = magicPool[(int)id];

		StartCoroutine (magicSpell.castMagic (gameObject, to));

		Debug.Log ("Attack using " + attackIDnames[(int)id]);


		wizardAnimator.SetBool ("Attack", false);
	}

}
