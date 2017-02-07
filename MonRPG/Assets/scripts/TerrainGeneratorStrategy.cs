using UnityEngine;
using System.Collections;
using terrain;

namespace terrainGenerationStrategies
{
	public abstract class TerrainGeneratorStrategy : MonoBehaviour
	{	
		public abstract void GenerateChunk (int x, int y, Chunk c, int seed);
	}
}