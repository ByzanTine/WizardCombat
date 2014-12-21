using UnityEngine;
using System.Collections;

public class MovableUnit : MonoBehaviour {
	public Vector3 destination;
	public GameObject explosion;
	public bool isMoving = false;
	public float speed;
	public Vector3 curSpeed;
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

		// Reflect if speed change 
		// change the orientation for effect glitches
		if ((rigidbody.velocity - curSpeed).magnitude > 0.1f)
		{
			// Debug.Log("Rotate Angle: " + Vector3.Angle(curSpeed, rigidbody.velocity));
			float angle = Vector3.Angle(curSpeed, rigidbody.velocity);
			Vector3 cross = Vector3.Cross(curSpeed, rigidbody.velocity);
			if (cross.y < 0) angle = -angle;
			transform.Rotate(new Vector3 (0, angle, 0));

			rigidbody.velocity = rigidbody.velocity.normalized * speed; // enfore a constant speed 
			curSpeed = rigidbody.velocity;  


		}



	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == TagList.Player
		    || other.gameObject.tag == TagList.Fireball){
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
		// TODO HARD CODE
		transform.Rotate (new Vector3 (0, 180, 0));
		this.destination = destination;
		// destination.y = transform.position.y;
		destination.y = 0.5f; // should be a little bit higher to separate from ground
		Vector3 moveDirection = (destination - transform.position).normalized;
		rigidbody.velocity = speed * moveDirection;
		curSpeed = rigidbody.velocity;

	}
}
