using Unity.VisualScripting;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private float spikeTimerMax;
    [SerializeField] private GameObject spike;
    [SerializeField] private float moveSpeed;
    private float spikeTimer;


    private float difficultyTimer;
  [SerializeField]  private float difficutlyTimerMax = 100f;

    private void Awake()
    {
        moveSpeed = 0f;
    }
    private void Update()
    {
        spikeTimer -= Time.deltaTime;
        difficultyTimer -= Time.deltaTime;
        if(spikeTimer <= 0)
        {
            spikeTimer = spikeTimerMax;
            Spawn();
        }
        if(difficultyTimer <= 0)
        {
            difficultyTimer = difficutlyTimerMax;
            IncreaseDifficulty();

        }
    }

    private void Spawn()
    {
       GameObject spikeObj = Instantiate(spike, transform.position, Quaternion.identity);
       Spike spikeScript = spikeObj.GetComponent<Spike>();
        if (spikeScript)
        {
           spikeScript.IncreaseSpeed(moveSpeed);
        }
        
    }
    private void IncreaseDifficulty()
    {
        spikeTimerMax -= 0.1f;
        moveSpeed += 0.1f;
    }
}
