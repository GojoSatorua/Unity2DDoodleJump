using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text scoreText;

    [Header("Settings:")]
    [SerializeField] private float scoreMultiplier = 10f;

    private float maxHeight;
    private int currentScore;

    private void Start()
    {
        if (player != null)
        {
            maxHeight = player.position.y;
        }
        UpdateScoreUI();
    }

    private void Update()
    {
        if (player == null) return;

        if (player.position.y > maxHeight)
        {
            maxHeight = player.position.y;
            currentScore = Mathf.FloorToInt(maxHeight * scoreMultiplier);
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}";
        }
    }
}