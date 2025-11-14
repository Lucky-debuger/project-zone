using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputActions inputActions;

    void Awake()
    {
        inputActions = new InputActions(); // 
        inputActions.Player.Click.performed += ctx => OnClick();
    }
    private void OnClick()
    {
        Debug.Log("Left mouse button clicked!");
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();
}
