using UnityEngine;
using System.Collections;

public class MovableUnit : MonoBehaviour {
	public Vector3 destination;
	public GameObject explosion;
	public bool isMoving = false;
	public float speed = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate (){
		if (isMoving) {
			// Debug.Log((transform.position - destination).magnitude);

			if ((transform.position - destination).magnitude < 1.0f){
				isMoving = false;
				// Cause Explosion Here
				Instantiate(explosion, destination, Quaternion.identity);
				Destroy(gameObject);
			}
			else {
				transform.position = Vector3.Lerp(transform.position, destination, speed*Time.fixedDeltaTime);
			}
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
		destination.y = 0.5f;
		isMoving = true;
	}
}
