using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using terrainGenerationStrategies;

namespace terrain
{
	public class Chunk
	{
		//chunk size
		public int lx = 10;
		public int ly = 10;
		public int lz = 10;
		public List<List<List<int>>> tiles;
		public List<List<List<GameObject>>> sprites;

		public void Reset ()
		{
			tiles = new List<List<List<int>>> (lx);
			sprites = new List<List<List<GameObject>>> (lx);
			for (int i = 0; i < lx; i++) {
				List<List<int>> l = new List<List<int>> (ly);
				List<List<GameObject>> ls = new List<List<GameObject>> (ly);
				for (int j = 0; j < ly; j++) {
					List<int> ll = new List<int> (lz);
					List<GameObject> lls = new List<GameObject> (lz);
					for (int k = 0; k < ly; k++) {
						lls.Add (null);
					}
					l.Add (ll);
					ls.Add (lls);
				}
				tiles.Add (l);
				sprites.Add (ls);
			}
		}

		public Chunk ()
		{
			Reset ();
		}
	}

	public class terrainGenerator : MonoBehaviour
	{
		private terrainGeneratorStrategy generator = null;
		public string generatorChoice;
		public int seed;

		private void setGenerator ()
		{
			if (generator == null) {
				switch (generatorChoice) {
				case "1":
					//Debug.Log ("CHOICE terrainGenerationStrategy1");
					generator = GetComponent<terrainGenerationStrategy1> ();
					break;
				default:
					//Debug.Log ("CHOICE terrainGeneratorStartegyRandom");
					generator = GetComponent<terrainGeneratorStartegyRandom> ();
					break;
				}
			}
		}
		
		void Awake ()
		{
			//Debug.Log ("AWAKE");
			setGenerator ();
		}


		public void GenerateChunk (int x, int y, Chunk c)
		{
			//Debug.Log ("GENERATION");
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