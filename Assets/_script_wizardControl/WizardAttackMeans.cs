using UnityEngine;
using System.Collections;

public class WizardAttackMeans : MonoBehaviour {
	/*
	 * This part will be easily scaled 
	 */
	public enum AttackID{
		fireball,
		meteor,
	};
	public string[] attackIDnames = {"fireball", "meteor"};
	// Use this for initialization
	private Animator wizardAnimator;
	private ShotSpawnController wc;
	void Start () {
		wizardAnimator = gameObject.GetComponentInChildren<Animator> ();
		wc = gameObject.GetComponent<ShotSpawnController>();
		int enumCount = System.Enum.GetValues (typeof(AttackID)).Length;

		Debug.Log ("Total Methods of attack that wizard can Use: " + enumCount);

		if (wc.shotSpawn.Length != wc.shot.Length 
		    || wc.shot.Length != enumCount ){
			Debug.LogError("Attack Methods does not match the shot spawn");
		
		}
	}
	
	public IEnumerator Attack(Vector3 to, AttackID id){
		wizardAnimator.SetBool ("Attack", true);
		yield return new WaitForSeconds (1.0f);


		wc.ShotByID(to, (int)id);
		Debug.Log ("Attack using " + attackIDnames[(int)id]);


		wizardAnimator.SetBool ("Attack", false);
	}
}
