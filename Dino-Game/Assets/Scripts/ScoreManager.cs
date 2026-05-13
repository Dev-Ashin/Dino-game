using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Spike>())
        {
            
            Spike spike = collision.gameObject.GetComponent<Spike>();
            score++;
            spike.DestroySelf();
            Debug.Log(score);
        }
    }
}
