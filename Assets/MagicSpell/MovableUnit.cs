using UnityEngine;
using System.Collections;

public class MovableUnit : MonoBehaviour {
	public Vector3 destination;
	public GameObject explosion;
	public bool isMoving = false;
	public float speed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate (){

		// If the object is already there, explode

		if ((transform.position - destination).magnitude < 1.0f){
			isMoving = false;
			// Cause Explosion Here
			Instantiate(explosion, destination, Quaternion.identity);
			Destroy(gameObject);
		}



	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == TagList.Player
		    || other.gameObject.tag == "Obstacle"){
			isMoving = false;
			// Cause Explosion Here
			Debug.Log ("Knocked On other, explode now");
			Debug.DrawLine (transform.position,
			                new Vector3(transform.position.x, 30.0f, transform.position.z),Color.red,10.0f);
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		
	}
	public void MoveTo(Vector3 destination) {

		this.destination = destination;
		// destination.y = transform.position.y;
		destination.y = 0.5f; // should be a little bit higher to separate from ground
		Vector3 moveDirection = (destination - transform.position).normalized;
		rigidbody.velocity = speed * moveDirection;

	}
}
