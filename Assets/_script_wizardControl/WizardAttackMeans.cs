using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WizardAttackMeans : MonoBehaviour {


	// Use this for initialization
	private Animator wizardAnimator;
	private MagicSpell magicSpell;
	private List<MagicSpell> magicPool;

	void Start () {
		int enumSize = System.Enum.GetValues (typeof(SpellDB.AttackID)).Length;
		Debug.Log ("INIT: Number of Spells a wizard can use: " + enumSize);
		magicPool = new List<MagicSpell>{new FireballSpell(), new MeteorSpell(), new ReflectSpell()};

		wizardAnimator = gameObject.GetComponentInChildren<Animator> ();
	}
	
	public IEnumerator Attack(SpellDB.AttackID id, Vector3 to = default(Vector3)){
		wizardAnimator.SetBool ("Attack", true);
		yield return new WaitForSeconds (1.0f);

		magicSpell = magicPool[(int)id];

		StartCoroutine (magicSpell.castMagic (gameObject, to));

		Debug.Log ("Attack using " + SpellDB.attackIDnames[(int)id]);


		wizardAnimator.SetBool ("Attack", false);
	}

}
