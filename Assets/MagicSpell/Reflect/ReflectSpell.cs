using UnityEngine;
using System.Collections;

public class ReflectSpell : MagicSpell {

	private GameObject reflector;
	
	public ReflectSpell()
	{
//		reflector = SpellDB.meteor;
	}
	public override IEnumerator castMagic (GameObject caster, Vector3 hitpoint = default(Vector3)) 
	{
		
		Debug.Log("Reflect Activiated!");
//		GameObject gb = GameObject.Instantiate (meteor, caster.transform.position, caster.transform.rotation) as GameObject;
//		MovableUnit movUnit = gb.GetComponent<MovableUnit> ();
//		movUnit.MoveTo (hitpoint);
		yield return new WaitForSeconds(0.1f);
	}
}
