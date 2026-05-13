using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {  get; private set; }
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
    }

    private void Update()
    {
       
    }
    public GameState GetState()
    {
        return state;
    }
}
