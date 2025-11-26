using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static event Action<Vector2> OnMouseMoved;
    public static event Action<Vector2> OnClickAtPositionPerformed;
    public static event Action OnClickPerformed;

    private InputActions inputActions;

    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Click.performed += ctx => OnClickPerformed?.Invoke();
        inputActions.Player.Click.performed += ctx => OnClickAtPositionPerformed?.Invoke(Mouse.current.position.ReadValue());
        
    }

    void Update()
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        OnMouseMoved?.Invoke(mousePos);
    }


    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();
}
