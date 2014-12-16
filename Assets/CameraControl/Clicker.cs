using UnityEngine;
using System.Collections;

public class Clicker : MonoBehaviour {

	private static Clicker instance;
	private Clicker() {}
	public static Clicker Instance
	{
		get
		{
			if (instance == null)
				instance = GameObject.FindObjectOfType(typeof(Clicker)) as  Clicker;
			return instance;
		}
	}
	public LayerMask collideLayer;// Only collide with the colliders in this layer
	// Event Handler
	public delegate void OnClickEvent(Vector3 g);
	public event OnClickEvent OnClickRight;
	public event OnClickEvent onClickLeft;

	// Handle our Ray and Hit
	void Update () 
	{
		
		if (Input.GetMouseButtonDown(1))
		{
			// Ray
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// Raycast Hit
			RaycastHit hit;
			Debug.DrawLine (camera.transform.position, Input.mousePosition);
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, collideLayer))
				OnClickRight(hit.point);// Notify of the event!

		}

		if (Input.GetMouseButtonDown(0))
		{
			// Ray
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// Raycast Hit
			RaycastHit hit;
			Debug.DrawLine (camera.transform.position, Input.mousePosition);
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, collideLayer))
				onClickLeft(hit.point);// Notify of the event!
			
		}

	}
}
