using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool StartGame = false;
    private Player player;
    public int levelStartingLength = 20;
    private float levelPartLength = 20f;
    public int minObstacleCountPerLevelPart;
    public int maxObstacleCountPerLevelPart;
    public int minCoinCountPerLevelPart;
    public int maxCoinCountPerLevelPart;
    private int[] pathPositionsZ = new int[3] { -5, 0, 5 };
    private float startingX = 9f;
    private float currentX;
    public List<string> Obstacles;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentX = startingX;
        for (int i = 0; i < levelStartingLength; i++)
        {
            SpawnLevelPart(currentX);
            SpawnLevelObstacles(currentX, Random.Range(minObstacleCountPerLevelPart, maxObstacleCountPerLevelPart + 1));
            SpawnCoins(currentX, Random.Range(minCoinCountPerLevelPart, maxObstacleCountPerLevelPart + 1));
        }
    }
    void Update()
    {
        if (currentX - player.currentX < 200f)
        {
            SpawnLevelPart(currentX);
            SpawnLevelObstacles(currentX, Random.Range(minObstacleCountPerLevelPart, maxObstacleCountPerLevelPart + 1));
            SpawnCoins(currentX, Random.Range(minCoinCountPerLevelPart, maxCoinCountPerLevelPart + 1));
        }


    }

    void SpawnLevelPart(float x)
    {
        PoolManager.GetObject("Level_part_01", new Vector3(currentX, 0, 0), Quaternion.identity);
        currentX += levelPartLength;
    }
    void SpawnLevelObstacles(float startingX, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var pathNumber = Random.Range(0, 3);
            var obstacle = Obstacles[Random.Range(0, Obstacles.Count)];
            float z = 0f;
            switch (pathNumber)
            {
                case 0:
                    z = pathPositionsZ[0];
                    break;
                case 1:
                    z = pathPositionsZ[1];
                    break;
                case 2:
                    z = pathPositionsZ[2];
                    break;
            }
            var x = Random.Range(startingX, startingX + 20);
            PoolManager.GetObject(obstacle, new Vector3(x, 1.2f, z), Quaternion.identity);
        }
    }
    void SpawnCoins(float startingX, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var pathNumber = Random.Range(0, 3);
            float z = 0f;
            switch (pathNumber)
            {
                case 0:
                    z = pathPositionsZ[0];
                    break;
                case 1:
                    z = pathPositionsZ[1];
                    break;
                case 2:
                    z = pathPositionsZ[2];
                    break;
            }
            var x = Random.Range(startingX, startingX + 20);
            PoolManager.GetObject("coin", new Vector3(x, 1.2f, z), Quaternion.identity);
        }
    }
}
