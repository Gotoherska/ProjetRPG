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
		public Chunk chunk;
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
				chunk = new Chunk (chunkSize,chunkSize,1);

				minX = 0;
				minY = 0;
				maxX = chunk.lx * blocSize;
				maxY = maxX;

				init = true;
			}
		}
	
		public void DisplayChunk (int x, int y)
		{
			Init ();
			generator.GetChunk (x, y, chunk);
		
			int posx = 0;
			int posy = 0;
			int posz = 0;
			Vector3 posT;
			GameObject t;

			foreach (List<List<int>> lx in chunk.tiles) {
				foreach (List<int> ly in lx) {
					foreach (int lz in ly) {

						posT.z = lz;
						posT.x = posx * blocSize;
						posT.y = posy * blocSize;

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
