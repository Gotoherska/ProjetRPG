using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using terrainGenerationStrategies;

namespace terrain
{
	public class Chunk {
	//public class Chunk : MonoBehaviour{
		//chunk size
		public int lx = 10;
		public int ly = 10;
		public int lz = 10;
		
		public List<List<List<int>>> tiles;
		public List<List<List<GameObject>>> sprites;

		public void Reset()
		{
			tiles = new List<List<List<int>>> (lx);
			sprites = new List<List<List<GameObject>>> (lx);
			for (int i = 0; i < lx; i++) {
				List<List<int>> l = new List<List<int>>(ly);
				List<List<GameObject>> ls = new List<List<GameObject>>(ly);
				for (int j = 0; j < ly; j++) {
					List<int> ll = new List<int>(lz);
					List<GameObject> lls = new List<GameObject>(lz);
					for (int k = 0; k < ly; k++) {
						lls.Add(null);
					}
					l.Add(ll);
					ls.Add(lls);
				}
				tiles.Add(l);
				sprites.Add(ls);
			}
		}

		public Chunk()
		{
			Reset ();
		}
	}
	public class terrainGenerator : MonoBehaviour {

		public terrainGeneratorStrategy generator;
		public string generatorChoice;

		
		void Awake()
		{
			switch(generatorChoice)
			{
			case "1":
				generator = GetComponent<terrainGenerationStrategy1>();

			default:
				generator = GetComponent<terrainGeneratorStartegyRandom>();
			}
		}

		//world heigth limit 
		public int z = 0;

		public void GenerateChunk(int x, int y, Chunk c){
			generator.GenerateChunk (x, y, c);
			/*c.Reset ();
			foreach(List<List<int>> l in c.tiles)
			{	
				foreach(List<int> ll in l)
				{			
					for(int i = 0; i < c.lz; i++)
					{
						int e = Random.Range(0,3);
						ll.Add(e);
					}
				}
			}*/
		}
		public void GetChunk(int x, int y, Chunk c){
			//no save system yet
			GenerateChunk (x, y, c);
		}
	}
}