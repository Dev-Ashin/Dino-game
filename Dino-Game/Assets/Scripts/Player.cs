using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler OnJump;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpHeight;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private bool isGrounded;


    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        if (InputManager.Instance)
        {
            InputManager.Instance.OnJump += InputManager_OnJump;
        }
        else
        {
            Debug.LogWarning("NO input manager");
        }
    }

    private void InputManager_OnJump(object sender, System.EventArgs e)
    {
        if (isGrounded)
        {
            OnJump?.Invoke(this, EventArgs.Empty);
            Jump();
            Debug.Log("On jump walk through");
            SoundManager.Instance.PlaySoundEffectsClip(clip, transform, 1);

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
