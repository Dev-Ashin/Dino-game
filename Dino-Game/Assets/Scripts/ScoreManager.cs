using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public event EventHandler OnScoreChanged;

    [SerializeField] private int score;

    [SerializeField] private HighScoreSO highScoreSO;

    private GameManager gameManager;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.GetState() == GameManager.GameState.Playing)
        {
            if (collision.gameObject.GetComponent<Spike>())
            {

                Spike spike = collision.gameObject.GetComponent<Spike>();
                IncreaseScore();
                spike.DestroySelf();
                Debug.Log(score);
            }
        }
    }

    private void IncreaseScore()
    {
        score++;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        if (score > highScoreSO.highScore)
        {
            IncreaseHighScore();
        }
       
    }

    private void IncreaseHighScore()
    {
        highScoreSO.highScore++;
    }

    public int GetHighScore()
    {
        return highScoreSO.highScore;
    }
    public int GetScore()
    {
       return  score;
    }
}
