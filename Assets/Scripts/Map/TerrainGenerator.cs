using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float step;
    [SerializeField] private GameObject firstLayer;
    [SerializeField] private GameObject lowerLayer;
    [SerializeField] private GameObject gameObjectParent;
    [SerializeField] private Vector2 dimension;
    [SerializeField] private int minDepth;
    private void Start()
    {
        // Offset the generation to the origin
        int xOffset = -1 * (int)(dimension.y / 2);
        int yOffset = -1 * (int)(dimension.x / 2);

        // Generates the Terrain
        for (int row = 0; row < dimension.y; row++)
        {
            for (int col = 0; col < dimension.x; col++)
            {
                int height = (int)(amplitude * Mathf.PerlinNoise(step * (col/dimension.x), step * (row/dimension.y)) - amplitude);
                for(int depth = height - 1; depth >= minDepth; depth--)
                {
                    Instantiate(lowerLayer, new Vector3(col+ xOffset, depth, row + yOffset), Quaternion.identity, gameObjectParent.transform);
                }
                Vector3 position = new Vector3(col + xOffset, height, row + yOffset);
                Instantiate(firstLayer, position, Quaternion.identity, gameObjectParent.transform);
            }
        }
    }
}
