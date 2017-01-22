using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using terrain;

namespace terrainGenerationStrategies
{
	public class terrainGenerationStrategy1 : terrainGeneratorStrategy
	{	
		public override void GenerateChunk (int x, int y, Chunk c, int seed)
		{			
			//Debug.Log ("GENERATION terrainGeneratorStrategy1");
			c.Reset ();
			foreach (List<List<int>> l in c.tiles) {	
				foreach (List<int> ll in l) {	
					int e = 0;
					for (int i = 0; i < c.lz; i++) {
						if (i == 0) {
							e = Random.Range (1, 3);
						} else if(i > 3){
							e = 0;
						}
						ll.Add (e);
					}
				}
			}
		}

	}
}