using UnityEngine;
using System.Collections;

public class FireballSpell : MagicSpell {
	private GameObject fireball;

	public FireballSpell()
	{
		fireball = SpellDB.fireball;
		Debug.Log("Constructor Loaded");
	}
	public override IEnumerator castMagic (GameObject caster, Vector3 hitpoint = default(Vector3)) 
	{

		Debug.Log("Fireball Activiated!");
		GameObject gb = GameObject.Instantiate (fireball, caster.transform.position, caster.transform.rotation) as GameObject;
		MovableUnit movUnit = gb.GetComponent<MovableUnit> ();
		movUnit.MoveTo (hitpoint);
		yield return new WaitForSeconds(0.1f);
	}
}
