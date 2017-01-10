using UnityEngine;
using System.Collections;

public class testTerrainInit : MonoBehaviour {

	public terrainDisplayer terrain;

	void Awake()
	{
		//Debug.Log ("test terrain 01");
		terrain = GetComponent<terrainDisplayer> ();
		terrain.DisplayChunk (0, 0);
	}

}
