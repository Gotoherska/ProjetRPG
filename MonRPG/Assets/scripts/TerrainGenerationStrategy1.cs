using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using terrain;

namespace terrainGenerationStrategies
{
	public class TerrainGenerationStrategy1 : TerrainGeneratorStrategy
	{	
		public override void GenerateChunk (int x, int y, Chunk c, int seed)
		{
			c.Reset ();
			foreach (List<List<int>> lx in c.tiles) {	
				int heigth = 0;
				foreach (List<int> ly in lx) {	
					int e = 0;
					if(heigth < 4){
						e = 1;
					}
					if(heigth == 4){
						e = 2;
					}
					ly.Add (e);
					heigth ++;
				}
			}
		}

	}
}