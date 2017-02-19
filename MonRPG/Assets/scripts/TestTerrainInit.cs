using UnityEngine;
using System.Collections;
using terrain;
using UnityEditor;

public class TestTerrainInit : MonoBehaviour {

	private TerrainDisplayer terrainDisplayer;

	void Awake()
	{
		//Debug.Log ("test terrain 01");
		terrainDisplayer = GetComponent<TerrainDisplayer> ();
		TerrainGenerator tg = GetComponent<TerrainGenerator> ();
		string s = tg.WorldDirectory();
		Debug.Log ("DELETE WORLD DATA: " + s);
		FileUtil.DeleteFileOrDirectory (s);
		terrainDisplayer.DisplayChunks (0, 0);
	}

}
