using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject Player;
    public int levelLength = 20;
    public float levelPartLength = 20f;
    private int[] pathPositionsZ = new int[3] { -5, 0, 5 };
    private float startingX = 0f;
    private float currentX;
    private GameObject[] ActiveLevelParts;
    private List<GameObject> ActiveGameObjects = new List<GameObject>();

    void Start()
    {
        ActiveLevelParts = new GameObject[levelLength];
        currentX = startingX;
        for (int i = 0; i < levelLength; i++)
        {
            SpawnLevelPart(currentX);
            SpawnLevelObjects();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ActiveLevelParts.Length; i++)
        {
            if (Player.transform.position.x - ActiveLevelParts[i].transform.position.x > 20f)
            {
                ActiveLevelParts[i].GetComponent<PoolObject>().ReturnToPool();
                ActiveLevelParts[i] = null;
                SpawnLevelPart(currentX);
            }
        }

    }

    void SpawnLevelPart(float x)
    {
        GameObject levelObject = PoolManager.GetObject("Level_part_01", new Vector3(currentX, 0, 0), Quaternion.identity);
        for (int i = 0; i < ActiveLevelParts.Length; i++)
        {
            if (ActiveLevelParts[i] == null)
            {
                ActiveLevelParts[i] = levelObject;
                break;
            }
        }
        currentX += levelPartLength;
    }
    void SpawnLevelObjects()
    {
        
    }
}
