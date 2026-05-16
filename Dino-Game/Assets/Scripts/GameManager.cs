using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {  get; private set; }

    public event EventHandler OnGameOver;
    public enum GameState
    {
        Playing,
        GameOver
    }
   

    private GameState state;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Player.Instance.OnDeath += Player_OnDeath;
        state = GameState.Playing;
    }

    private void Player_OnDeath(object sender, System.EventArgs e)
    {
        state = GameState.GameOver;
        OnGameOver?.Invoke(this, EventArgs.Empty);

    }

    private void Update()
    {
       
    }

    public void StartNewRun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public GameState GetState()
    {
        return state;
    }
}
