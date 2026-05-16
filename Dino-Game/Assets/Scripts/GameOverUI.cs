using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideGameOver();
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }

    private void GameManager_OnGameOver(object sender, System.EventArgs e)
    {
        ShowGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        scoreText.text = ScoreManager.Instance.GetScore().ToString();
        highScoreText.text = ScoreManager.Instance.GetHighScore().ToString();
    }


    private void HideGameOver()
    {
        gameOverUI.SetActive(false);
    }
}
