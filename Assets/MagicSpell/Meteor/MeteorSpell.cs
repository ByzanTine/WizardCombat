using UnityEngine;
using System.Collections;

public class MeteorSpell : MagicSpell {

	private GameObject meteor;

	public MeteorSpell()
	{
		meteor = SpellDB.meteor;
	}
	public override IEnumerator castMagic (GameObject caster, Vector3 hitpoint = default(Vector3)) 
	{
		
		Debug.Log("Meteor Activiated!");
		Vector3 castLocation = hitpoint + new Vector3 (0, 20, 0);
		GameObject gb = GameObject.Instantiate (meteor, castLocation, caster.transform.rotation) as GameObject;
		MovableUnit movUnit = gb.GetComponent<MovableUnit> ();
		movUnit.MoveTo (hitpoint);
		yield return new WaitForSeconds(0.1f);
	}
}
