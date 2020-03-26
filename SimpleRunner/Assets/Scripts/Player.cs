using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardMoveSpeed = 20f;
    public float sideMoveSpeed = 5f;
    private bool StartGame = false;
    private bool isChangingLane;
    private float zToReach = 0f;
    public float currentX = 0f;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) StartGame = true;
        if (StartGame)
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
            transform.Translate(Vector3.right * forwardMoveSpeed * Time.deltaTime);
            currentX = transform.position.x;
        }

    }
}
