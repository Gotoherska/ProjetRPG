using UnityEngine;
using System.Collections;
using terrain;

namespace terrainGenerationStrategies
{
	public abstract class terrainGeneratorStrategy : MonoBehaviour
	{	
		public abstract void GenerateChunk (int x, int y, Chunk c, int seed);
	}
}