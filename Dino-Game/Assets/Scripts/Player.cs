using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler OnJump;
    public event EventHandler OnHit;
    public event EventHandler OnDeath;

    [SerializeField] private int life;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpHeight;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip hitClip;

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

    private void Update()
    {
        if(life <= 0)
        {
            Die();
        }
    }

    private void InputManager_OnJump(object sender, System.EventArgs e)
    {
        if (isGrounded)
        {
            OnJump?.Invoke(this, EventArgs.Empty);
            Jump();
            Debug.Log("On jump walk through");
            SoundManager.Instance.PlaySoundEffectsClip(jumpClip, transform, 1);

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
            Hit();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            isGrounded = false;
        }
    }

    private void Hit()
    {
        OnHit?.Invoke(this, EventArgs.Empty);
        SoundManager.Instance.PlaySoundEffectsClip(hitClip, transform, 1);
        life--;
    }

    private void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
        Debug.Log("GameOver");
        DestroySelf();
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
