using UnityEngine;
using System.Collections;
using terrain;

public class TestTerrainInit : MonoBehaviour {

	private TerrainDisplayer terrainDisplayer;

	void Awake()
	{
		//Debug.Log ("test terrain 01");
		terrainDisplayer = GetComponent<TerrainDisplayer> ();
		terrainDisplayer.DisplayChunk (0, 0);
	}

}
