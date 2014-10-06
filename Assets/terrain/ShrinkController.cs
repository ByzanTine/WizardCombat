using UnityEngine;
using System.Collections;

public class ShrinkController : MonoBehaviour {
	private float tic;
	private float factor;
	private float factorLowerBound = 0.2f;
	// Linear related to the frames that the terrain will exist
	// Currently 100*frame_rate of FIxedUpdate
	[Range(0,1)]
	public float decayBeta = 0.01f; 
	private float timer;

	Vector3 orginalScale;
	// Use this for initialization
	void Start () {
		tic = Time.time;
		factor = 1.0f;
		orginalScale = transform.localScale;
		InvokeRepeating ("UpdateStandZone", 0.0f, 10.0f);
	}
	void FixedUpdate () {
		if (factor <= factorLowerBound) {
			CancelInvoke();
		}
	}
	// Now update zone is discrete
	// To make it continous, just make it into update
	void UpdateStandZone () {

		if (factor > 0.1f) {
			factor -= decayBeta*(Time.time-tic); // 0 to 1
			factor = Mathf.Clamp(factor, factorLowerBound, 1.0f);
			tic = Time.time;
			transform.localScale = orginalScale * factor;
		}

	}
}
