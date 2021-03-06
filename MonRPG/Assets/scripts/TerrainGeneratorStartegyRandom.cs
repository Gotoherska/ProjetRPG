using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using terrain;

namespace terrainGenerationStrategies
{
	public class TerrainGeneratorStartegyRandom : TerrainGeneratorStrategy
	{

	
		public override void GenerateChunk (int x, int y, Chunk c, int seed)
		{
			//Debug.Log ("GENERATION terrainGeneratorStartegyRandom");
			c.Reset ();
			foreach (List<List<int>> l in c.tiles) {	
				foreach (List<int> ll in l) {			
					for (int i = 0; i < c.lz; i++) {
						int e = Random.Range (0, 3);
						ll.Add (e);
					}
				}
			}
		}
	}
}