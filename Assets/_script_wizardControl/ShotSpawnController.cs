using UnityEngine;
using System.Collections;

public class ShotSpawnController : MonoBehaviour {


	// A array of location to instantiate the object
	public Transform[] shotSpawn;

	public GameObject[] shot;


	public void ShotByID(Vector3 to, int id){
		if (id >= shot.Length){
			Debug.Log("No shotspwan avaiable");
		}
		else{
			GameObject gb = Instantiate (shot[id], shotSpawn[id].position, shotSpawn[id].rotation) as GameObject;
			MovableUnit movUnit = gb.GetComponent<MovableUnit> ();
			movUnit.MoveTo (to);
		}
	}
}
