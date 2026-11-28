using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI:")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text finalScoreText;

    [Header("Fall Check:")]
    [SerializeField] private Transform player;
    [SerializeField] private float fallOffset = 2f;

    private Camera mainCam;
    private bool isGameOver;

    private void Start()
    {
        mainCam = Camera.main;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (isGameOver || player == null || mainCam == null) return;

        float bottomLimit = mainCam.transform.position.y - mainCam.orthographicSize - fallOffset;
        if (player.position.y < bottomLimit)
        {
            ShowGameOver();
        }
    }

    public void ShowGameOver(int finalScore = 0)
    {
        if (isGameOver) return;
        isGameOver = true;

        if (finalScoreText != null)
        {
            finalScoreText.text = $"Score: {finalScore}";
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}