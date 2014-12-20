using UnityEngine;
using System.Collections;
// Parent Spell Class
public abstract class MagicSpell{
	float cooldown;
	// cast a magic 
	// make it a coroutine to delay if neccessary
	public abstract IEnumerator castMagic(GameObject caster, Vector3 hitpoint = default(Vector3));


}
