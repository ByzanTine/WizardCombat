using UnityEngine;
using System.Collections;

public class OnDangerEffect : MonoBehaviour {

	private GameObject DamagingEffect;
	private Wizard wizard;
	void Awake () {
		// DamagingEffect = GameObject.FindGameObjectWithTag (TagList.DamagingEffect);
		DamagingEffect = transform.FindChild ("DamagingFlame").gameObject;
		wizard = gameObject.GetComponent<Wizard> ();
	}
	void FixedUpdate () {
		DamagingEffect.SetActive (wizard.standState == Wizard.WizardStandState.OnDanger);
	}
}
