using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float sideMoveSpeed = 5f;
    private bool isChangingLane;
    private float zToReach = 0f;
    [HideInInspector]
    public float currentX = 0f;
    private void Start()
    {
        if (PlayerPrefs.HasKey("CoinCount"))
            PlayerInfo.CoinCount = PlayerPrefs.GetInt("CoinCount");
        else PlayerInfo.CoinCount = 0;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!PlayerInfo.GameOver)
                LevelManager.StartGame = true;
            else
            {
                PlayerInfo.GameOver = false;
                PlayerInfo.DistanceTraveled = 0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (LevelManager.StartGame)
        {
            if (isChangingLane)
            {
                if (transform.position.z != zToReach)
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, zToReach), sideMoveSpeed * Time.deltaTime);
                else
                    isChangingLane = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.D) && transform.position.z != -5)
                {
                    isChangingLane = true;
                    zToReach -= 5f;
                }
                if (Input.GetKeyDown(KeyCode.A) && transform.position.z != 5)
                {
                    isChangingLane = true;
                    zToReach += 5f;
                }
            }
            currentX = transform.position.x;
            PlayerInfo.DistanceTraveled = currentX;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            LevelManager.StartGame = false;
            PlayerInfo.GameOver = true;
            PlayerPrefs.SetInt("CoinCount", PlayerInfo.CoinCount);
            PlayerPrefs.Save();
        }
        else if (other.gameObject.layer == 9)
        {
            PlayerInfo.CoinCount++;
            other.gameObject.GetComponent<PoolObject>().ReturnToPool();
            Debug.Log(PlayerInfo.CoinCount);
        }
    }
}
