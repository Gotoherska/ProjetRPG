using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using terrainGenerationStrategies;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace terrain
{

	public class TerrainGenerator : MonoBehaviour
	{
		private TerrainGeneratorStrategy generator = null;
		public string generatorChoice;
		public int seed;
		public string world = "GenericWorldName";

		private void checkGenerator ()
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
			checkGenerator ();
		}

		public void GenerateChunk (int x, int y, Chunk c)
		{
			checkGenerator ();

			generator.GenerateChunk (x, y, c, seed);			
			
			BinaryFormatter bf = new BinaryFormatter ();
			CheckWorldPath (x);
			FileStream fs = File.Create (WorldPath(x,y));
			bf.Serialize (fs, c);
			fs.Close ();
		}

		public void GetChunk (int x, int y, Chunk c)
		{			
			BinaryFormatter bf = new BinaryFormatter ();
			CheckWorldPath (x);
			if (File.Exists (WorldPath(x,y))) {
				FileStream fs = File.Open(WorldPath(x,y), FileMode.Open);
				c = (Chunk) bf.Deserialize(fs);
				fs.Close();
			} else {
				Debug.Log("GENERATE CHUNK :" + x + " : " + y);
				GenerateChunk (x, y, c);
			}
		}
		
		private void CheckWorldPath(int x)
		{
			string path = WorldPathAux(x);
			if(!Directory.Exists(path))
			{    
				Directory.CreateDirectory(path);				
			}
		}
		public string WorldDirectory()
		{
			return Application.persistentDataPath + "/MyRPG/" + world;
		}
		private string WorldPathAux(int x)
		{
			return Application.persistentDataPath + "/MyRPG/" + world + "/" + x;
		}
		private string WorldPath(int x, int y)
		{
			return WorldPathAux(x) + "/" + y + ".dat";
		}
	}
}