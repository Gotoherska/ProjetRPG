using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using terrainGenerationStrategies;

namespace terrain
{

	public class TerrainGenerator : MonoBehaviour
	{
		private TerrainGeneratorStrategy generator = null;
		public string generatorChoice;
		public int seed;

		private void setGenerator ()
		{
			if (generator == null) {
				switch (generatorChoice) {
				case "1":
					generator = GetComponent<TerrainGenerationStrategy1> ();
					break;
				default:
					generator = GetComponent<TerrainGeneratorStartegyRandom> ();
					break;
				}
			}
		}
		
		void Awake ()
		{
			setGenerator ();
		}

		public void GenerateChunk (int x, int y, Chunk c)
		{
			setGenerator ();
			generator.GenerateChunk (x, y, c, seed);
		}

		public void GetChunk (int x, int y, Chunk c)
		{
			//no save system yet
			GenerateChunk (x, y, c);
		}
	}
}