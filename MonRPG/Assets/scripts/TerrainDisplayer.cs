using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace terrain
{
	public class TerrainDisplayer : MonoBehaviour
	{

		private TerrainGenerator generator;
		public GameObject[] grass;
		public GameObject[] dirt;
//		public Chunk chunk;
		public List<List<Chunk>> chunks;
		public Vector2 currentChunk;
		private bool init = false;
		public int  chunkSize = 10;

		public float maxX;
		public float maxY;
		public float minX;
		public float minY;
	
		//length and width of the tiles for adjustments
		private float blocSize = 2.56f;
	
		void Init ()
		{
			if (!init) {
				generator = GetComponent<TerrainGenerator> ();
				//				chunk = new Chunk (chunkSize,chunkSize,1);
				Chunk chunk = new Chunk (chunkSize,chunkSize,1);
				chunks = new List<List<Chunk>>(3);
				for(int i = 0; i < 3; i++)
				{
					List<Chunk> cl = new List<Chunk>(3);
					for(int j = 0; j < 3; j++)
					{
						chunk = new Chunk (chunkSize,chunkSize,1);
						cl.Add(chunk);
					}
					chunks.Add(cl);
				}
				//TODO: create nth dimension list in util namespace



				minX = 0;
				minY = 0;
				maxX = chunk.lx * blocSize;
				maxY = maxX;

				init = true;
			}
		}
		public void DisplayChunks (int x, int y)
		{
			Init ();
			int offsetx = -1;
			Debug.Log("DISPLAY CHUNKS");
			foreach (List<Chunk> l in chunks) {
				int offsety = -1;
				foreach (Chunk c in l) {
					Debug.Log("chunk: " + x + offsetx + " : " + y + offsety);
					DisplayChunk (c, x, y, offsetx, offsety);
					offsety++;
				}
				offsetx++;
			}
		}
		public void DisplayChunk (Chunk chunk, int x, int y, int offsetx, int offsety)
		{
			generator.GetChunk (x + offsetx, y + offsety, chunk);
		
			float blocOffsetx = offsetx * chunk.lx * blocSize;
			float blocOffsety = offsety * chunk.ly * blocSize;

			int posx = 0;
			int posy = 0;
			int posz = 0;
			Vector3 posT;
			GameObject t;
			foreach (List<List<int>> lx in chunk.tiles) {
				foreach (List<int> ly in lx) {
					foreach (int lz in ly) {

						posT.z = lz;
						posT.x = posx * blocSize + blocOffsetx;
						posT.y = posy * blocSize + blocOffsety;

						if (lz != 0) {
							if (lz == 1) {
								t = dirt [0];
							} else {
								t = grass [0];
							}
							chunk.sprites [posx] [posy] [posz] = Instantiate (t, posT, Quaternion.identity) as GameObject;
						}
						posz ++;
					}
					posz = 0;
					posy ++;
				}
				posy = 0;
				posx ++;
			}
		}

		void Update ()
		{
		}
	}
}
