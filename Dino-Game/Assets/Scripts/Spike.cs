using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float moveSpeed;


    private void Update()
    {
        MoveLeft();
    }
    public void Setup(float speed)
    {
        moveSpeed = speed;
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
    public void IncreaseSpeed(float moveSpeed)
    {
        this.moveSpeed += moveSpeed;
    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
