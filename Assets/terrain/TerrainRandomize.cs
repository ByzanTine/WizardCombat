using UnityEngine;
using System.Collections;

public class TerrainRandomize : MonoBehaviour {
	Terrain magma;
	private int hmWidth;
	private int hmHeight;
	public bool isRandomizedMoving = false;
	public bool doMagmaBurst = false;
	public GameObject burstEffect;
	// Use this for initialization
	void Start () {
		magma = Terrain.activeTerrain;
		hmWidth = magma.terrainData.heightmapWidth;
		hmHeight = magma.terrainData.heightmapHeight;


	}
	
	// Update is called once per frame
	// TODO Optimize the magma moving 
	/*
	 * Only when player is near the magma, the magma moves.
	 * Namely, magma moves rendered with camera
	 */
	void FixedUpdate () {
		if (isRandomizedMoving){
			float[,] heights = magma.terrainData.GetHeights (0, 0, hmWidth, hmHeight);
			for (int i = 0; i < hmHeight; i+=1){
				for (int j = 0; j < hmWidth; j+=1){


					heights[i,j] = 0;
				}
			}

			magma.terrainData.SetHeights (0, 0, heights);
		}
	
	}

	void Update (){
		if (doMagmaBurst){

		}
	}
}
