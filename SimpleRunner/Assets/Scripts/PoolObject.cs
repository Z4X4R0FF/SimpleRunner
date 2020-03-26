using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public Player player;
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if (player.currentX - transform.position.x > 20f)
            ReturnToPool();
    }
}
