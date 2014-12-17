using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
	public GameObject target;
	private Vector3 offset;
	public float damping = 10;
	public float distance = 10;
	public float height = 20;
	// Use this for initialization
	void Start () {

		offset = new Vector3(-distance,height,-distance);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 desiredPosition = target.transform.position + offset;
		Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
		transform.position = position;
		transform.LookAt (target.transform);
	}
}
