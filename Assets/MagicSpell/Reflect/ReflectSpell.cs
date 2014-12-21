using UnityEngine;
using System.Collections;

public class ReflectSpell : MagicSpell {

	private GameObject reflector;
	
	public ReflectSpell()
	{
		reflector = SpellDB.reflector;
	}
	public override IEnumerator castMagic (GameObject caster, Vector3 hitpoint = default(Vector3)) 
	{
		yield return new WaitForSeconds(0.1f);
		Debug.Log("Reflect Activiated!");
		GameObject gb = GameObject.Instantiate (reflector, caster.transform.position, caster.transform.rotation) as GameObject;
		gb.transform.parent = caster.transform;

	}
}
