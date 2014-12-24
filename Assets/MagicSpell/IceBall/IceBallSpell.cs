using UnityEngine;
using System.Collections;

public class IceBallSpell : MagicSpell {
	private GameObject iceball;
	
	public IceBallSpell()
	{
		iceball = SpellDB.iceball;
		Debug.Log("Constructor Loaded");
	}
	public override IEnumerator castMagic (GameObject caster, Vector3 hitpoint = default(Vector3)) 
	{
		Quaternion lookedQua = Quaternion.LookRotation (hitpoint - caster.transform.position);
		GameObject gb = GameObject.Instantiate (iceball, caster.transform.position, lookedQua) as GameObject;
		
		
		MovableUnit movUnit = gb.GetComponent<MovableUnit> ();
		movUnit.MoveTo (hitpoint);
		yield return new WaitForSeconds(0.1f);
	}
}
