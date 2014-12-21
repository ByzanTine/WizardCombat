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

//		Debug.Log("Fireball Activiated!");
//		float transformed_angle = Vector3.Angle (new Vector3 (0, 0, 1), hitpoint-caster.transform.position);
//
//		Debug.Log ("Angle: " + transformed_angle);
		Quaternion lookedQua = Quaternion.LookRotation (hitpoint - caster.transform.position);
		GameObject gb = GameObject.Instantiate (fireball, caster.transform.position, lookedQua) as GameObject;


		MovableUnit movUnit = gb.GetComponent<MovableUnit> ();
		movUnit.MoveTo (hitpoint);
		yield return new WaitForSeconds(0.1f);
	}
}
