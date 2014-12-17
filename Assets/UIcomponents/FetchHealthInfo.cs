using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FetchHealthInfo : MonoBehaviour {
	public GameObject player;
	private PlayerWizard playerWizard;
	private Slider slider;
	// Update is called once per frame
	void Start () {
		playerWizard = player.GetComponent<PlayerWizard> ();
		slider = GetComponent<Slider> ();
	}
	void Update () {
		slider.value = playerWizard.health;
	}
}
