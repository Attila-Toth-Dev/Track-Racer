using System;

using UnityEngine;

using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 100;
    
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    public float offsetX = 100;
    public float offsetY = 100;

    private void Start()
    {
        offsetX = Random.Range(0, 99999f);
        offsetY = Random.Range(0, 99999f);
    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        offsetX += Time.deltaTime;
        offsetY += Time.deltaTime;
    }

    private TerrainData GenerateTerrain(TerrainData _terrainData)
    {
        _terrainData.heightmapResolution = width + 1;
        
        _terrainData.size = new Vector3(width, depth, height);
        _terrainData.SetHeights(0, 0, GenerateHeights());

        return _terrainData;
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    private float CalculateHeight(int _x, int _y)
    {
        float xCoord = (float)_x / width * scale + offsetX;
        float yCoord = (float)_y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
