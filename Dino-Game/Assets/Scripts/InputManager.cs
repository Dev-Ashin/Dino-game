using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {  get; private set; }

    public event EventHandler OnJump;

    private PlayerInput playerInput;
    
    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.Player.Jump.performed += Jump_performed;
        

    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
       OnJump?.Invoke(this, EventArgs.Empty);
    }
}
