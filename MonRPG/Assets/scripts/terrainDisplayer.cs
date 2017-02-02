using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using terrain;

public class terrainDisplayer : MonoBehaviour {
	private terrainGenerator generator;
		
	public GameObject[] grass;
	public GameObject[] water;
	private Chunk chunk;
	private bool init = false;
	
	public float maxX;
	public float maxY;
	public float minX;
	public float minY;
	
	//length and width of the tiles for adjustments
	public float stretchX = 2.56f;
	public float stretchY = 7.68f;
	public float wallSize = 7.68f - 2.56f;

	int viewLevel;
	public int playerLevel;
	
	void Init()
	{
		if (!init) {
			generator = GetComponent<terrainGenerator> ();
			chunk = new Chunk();
			viewLevel = chunk.lz;

			minX = 0;
			minY = 0;
			maxX = chunk.lx * stretchX;
			maxY = maxX + wallSize;

			init = true;
		}
	}

	public bool changeViewLevelInc()
	{
		if (viewLevel < chunk.lz) {
			viewLevel++;
			changeViewLevel (viewLevel);	
			return true;
		}
		return false;
	}
	public bool changeViewLevelDec()
	{
		if (viewLevel > 0) {
			viewLevel--;
			changeViewLevel (viewLevel);	
			return true;
		}
		return false;
	}
	
	public void changeViewLevel(int z)
	{ 
		Debug.Log ("heigth: " + z);
		viewLevel = z;
//		minY = stretchX * z + wallSize;
//		maxY = maxX + minY;
		playerLevel = viewLevel;
		updateMinMaxPos ();
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
		Init ();
		generator.GetChunk (x, y, chunk);
		
		int posx = 0;
		int posy = 0;
		int posz = 0;
		Vector3 posT;
		GameObject t;

		foreach(List<List<int>> l in chunk.tiles) {
			foreach(List<int> ll in l) {
				foreach(int tile in ll) {
					posT = computeTilePos(posx, posy, posz);

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
						chunk.sprites[posx][posy][posz] = Instantiate(t, posT, Quaternion.identity) as GameObject;
					}
					posz ++;
				}
				posz = 0;
				posy ++;
			}
			posy = 0;
			posx ++;
		}
		changeViewLevel (viewLevel);
	}
	private Vector3 computeTilePos(int x, int y, int z){
		Vector3 pos = new Vector3 ();
		float offsetPerspective;
		
		offsetPerspective = z * wallSize * stretchX;
		pos.x = x * stretchX;
		pos.y = y * stretchX + offsetPerspective;
		pos.z = -z;

		return pos;
	}
	//ignoring the wall part
	private float computeTileMinY(int x, int y, int z){
		GameObject t = chunk.sprites [x] [y] [z];
		return t.transform.position.y - stretchY/2 + wallSize;
	}
	//ignoring the wall part
	private float computeTileMaxY(int x, int y, int z){
		GameObject t = chunk.sprites [x] [y] [z];		
		return t.transform.position.y + stretchY/2 + wallSize;
	}
	//ignoring the wall part
	private float computeTileMinX(int x, int y, int z){
		GameObject t = chunk.sprites [x] [y] [z];		
		return t.transform.position.x - stretchX/2;
	}
	//ignoring the wall part
	private float computeTileMaxX(int x, int y, int z){
		GameObject t = chunk.sprites [x] [y] [z];		
		return t.transform.position.x + stretchX/2;
	}
	private void updateMinMaxPos(){
		Debug.Log ("playerLevel: " + playerLevel);
		minY = computeTileMinY (0, 0, playerLevel-1);
		minX = computeTileMinX (0, 0, playerLevel-1);
		maxY = computeTileMaxY (chunk.lx-1, chunk.ly-1, playerLevel-1);
		maxX = computeTileMaxX (chunk.lx-1, chunk.ly-1, playerLevel-1);

	}
	void Update()
	{
//		if (Input.GetKeyDown (KeyCode.P)) {
//			changeViewLevelInc();
//		}
//		if (Input.GetKeyDown (KeyCode.M)) {
//			changeViewLevelDec();
//		}
	}
}
