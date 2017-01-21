using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using terrain;

public class terrainDisplayer : MonoBehaviour {

	public terrainGenerator generator;

	
	public GameObject[] grass;
	public GameObject[] water;
	public Chunk chunk;
	private bool init = false;
	
	//length and width of the tiles for adjustments
	float strechX = 2.5f;
	float strechY = 2.5f;
	float wallSize = 2f;

	int viewLevel;
	
	void Init()
	{
		if (!init) {
			generator = GetComponent<terrainGenerator> ();
			chunk = new Chunk();
			viewLevel = chunk.lz;
			init = true;
		}
	}
	public void changeViewLevelInc()
	{
		if (viewLevel < chunk.lz) {
			viewLevel++;
			changeViewLevel (viewLevel);
	
		}
	}
	public void changeViewLevelDec()
	{
		if (viewLevel > 0) {
			viewLevel--;
			changeViewLevel (viewLevel);
		}
	}
	
	public void changeViewLevel(int z)
	{ 
		Debug.Log ("heigth: " + z);
		viewLevel = z;
		for(int i = 0; i < chunk.lx; i++)
		{
			for(int j = 0; j < chunk.ly; j++)
			{
				for(int k = 0; k < chunk.lz; k++)
				{
					if(k <= z)
					{
						if(chunk.sprites[i][j][k] != null)
						{
							chunk.sprites[i][j][k].SetActive(true);
						}
					}
					else{
						if(chunk.sprites[i][j][k] != null)
						{
							chunk.sprites[i][j][k].SetActive(false);
						}
					}
				}				
			}
		}
	}

	public void DisplayChunk(int x, int y)
	{
		//Debug.Log("display chunk");
		Init ();
		generator.GetChunk (0, 0, chunk);
		//Debug.Log ("chunk: " + chunk.tiles.Count );
		
		int posx = 0;
		int posy = 0;
		int posz = 0;
		Vector3 post = new Vector3(0,0,0);
		GameObject t;

		foreach(List<List<int>> l in chunk.tiles) {
			//Debug.Log("X: " + posx);
			foreach(List<int> ll in l) {
				foreach(int tile in ll) {
				//Debug.Log("Y: " + posy);
					//tiles
					post = new Vector3(posx * strechX, 
					                   (posy - (posz * wallSize)) * strechY, 
					                  posz);

					if(tile != 0)
					{
						if(tile == 1)
						{
							t = grass[0];
						}
						else
						{
							t = water[0];
						}
						//tiles
						chunk.sprites[posx][posy][posz] = Instantiate(t, post, Quaternion.identity) as GameObject;
					}
					posz ++;
				}
				//Debug.Log("instantiated tile ",o);
				/*Debug.Log("instantiated tile at " + pos.x.ToString() 
				          + ":" + pos.y 
				          + ":" + pos.z);
				*/
				posz = 0;
				posy ++;
			}
			posy = 0;
			posx ++;
		}
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.I)) {
			changeViewLevelInc();
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			changeViewLevelDec();
		}
	}
}
