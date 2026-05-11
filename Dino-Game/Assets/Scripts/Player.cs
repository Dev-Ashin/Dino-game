using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpHeight;

    private bool isGrounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        InputManager.Instance.OnJump += InputManager_OnJump;
    }

    private void InputManager_OnJump(object sender, System.EventArgs e)
    {
        if (isGrounded)
        {
            Jump();
        }
       
    }
    

    private void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            isGrounded = true;
        }

        if (collision.gameObject.GetComponent<Spike>())
        {
            Debug.Log("GameOver");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            isGrounded = false;
        }
    }
}
