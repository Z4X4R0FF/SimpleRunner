using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Animator animator;
    public Text gameOverText;
    public Text distanceText;
    private int score;
    private void Start()
    {
        score = PlayerInfo.CoinCount;
        scoreText.text = $"Coins {score}";
    }
    private void Update()
    {
        if (score != PlayerInfo.CoinCount)
        {
            score = PlayerInfo.CoinCount;
            scoreText.text = $"Coins {score}";
            animator.SetTrigger("Change");

        }
        distanceText.text = $"Distance: {PlayerInfo.DistanceTraveled}";
        if (PlayerInfo.GameOver)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
}
