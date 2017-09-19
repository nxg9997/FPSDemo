using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TerrainGen : MonoBehaviour {

	private TerrainData myTerrainData;
	public Vector3 worldSize;
	public int resolution = 129;
	float[,] terrain;


	void Start () 
	{
		myTerrainData = gameObject.GetComponent<TerrainCollider> ().terrainData;
		worldSize = new Vector3 (200, 50, 200);
		myTerrainData.size = worldSize;
		myTerrainData.heightmapResolution = resolution;
		terrain = new float[resolution, resolution];

		// Fill the height array with values!
		// Uncomment the Ramp and Perlin methods to test them out!
		//Flat(1.0f);
		//Ramp();
		Terrain();

		// Assign values from heightArray into the terrain object's heightmap
		myTerrainData.SetHeights (0, 0, terrain);
	}


	void Update () 
	{

	}

	private void Terrain()
	{
		//Random rgen = new Random();
		for (int i = 0; i < resolution; i++)
		{
			for (int j = 0; j < resolution; j++)
			{
				terrain [i, j] = UnityEngine.Random.Range (0.0f, 0.1f);//rgen.Next(-3, 4);
			}
		}

		for (int i = 0; i < resolution; i++)
		{
			for (int j = 0; j < resolution; j++)
			{
				float top = 0;
				float bot = 0;
				float right = 0;
				float left = 0;
				float div = 1;
				try
				{
					//if (terrain[i,j] == 3 || terrain[i,j] == -3)
					//{
					/*int keep = UnityEngine.Random.Range(0, 5);
					if (keep == 0)
					{
						throw new Exception();
					}*/
					//}
					if (i == 0 && j == 0) //0,0
					{
						right = terrain[i + 1, j];
						bot = terrain[i, j + 1];
						div = 2;
					}
					else if (j == resolution && i == resolution) //M,M
					{
						top = terrain[i, j - 1];
						left = terrain[i - 1, j];
						div = 2;
					}
					else if (j == 0 && i == resolution) //0,M
					{
						left = terrain[i - 1, j];
						bot = terrain[i, j + 1];
						div = 2;
					}
					else if (j == resolution && i == 0) //M,0
					{
						top = terrain[i, j - 1];
						right = terrain[i + 1, j];
						div = 2;
					}
					else if (i == resolution) //x,M
					{
						top = terrain[i, j - 1];
						bot = terrain[i, j + 1];
						left = terrain[i - 1, j];
						div = 3;
					}
					else if (j == resolution) // M,x
					{
						left = terrain[i - 1, j];
						right = terrain[i + 1, j];
						top = terrain[i, j - 1];
						div = 3;
					}
					else if (i == 0) //x,0
					{
						top = terrain[i, j - 1];
						bot = terrain[i, j + 1];
						right = terrain[i + 1, j];
						div = 3;
					}
					else if (j == 0) //0,x
					{
						right = terrain[i + 1, j];
						left = terrain[i - 1, j];
						bot = terrain[i, j + 1];
						div = 3;
					}
					else
					{
						right = terrain[i + 1, j];
						left = terrain[i - 1, j];
						bot = terrain[i, j + 1];
						top = terrain[i, j - 1];
						div = 4;
					}
					terrain[i, j] = (top + bot + right + left) / div;
				}
				catch (Exception) { };
			}
		}
	}
}
