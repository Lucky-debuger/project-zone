using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Canvas inputCanvas;
    [SerializeField] bool isJoystick;

    public float movementSpeed;

    // Проверка движения перса

    private float movementCheckInterval = 0.2f;
    private float timeSinceLastCheck = 0f;
    private bool isCurrentyMoving = false;

    // Добавляем кэшированные векторы для оптимизации 
    private Vector2 movementDirection;
    private Vector2 newVelocity;

    public static Action<bool> OnMovementStateChanged;
    public static Action OnContinuousMovement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        EnableJoystickInput();
    }

    private void FixedUpdate()
    {
        if (isJoystick)
        {
            movementDirection = new Vector2(joystick.Direction.x, joystick.Direction.y);
            
            newVelocity.x = movementDirection.x * movementSpeed;
            newVelocity.y = movementDirection.y * movementSpeed;
            _rigidbody.velocity = newVelocity;

            timeSinceLastCheck += Time.fixedDeltaTime;

            if (timeSinceLastCheck >= movementCheckInterval)
            {
                CheckMovementState();
                timeSinceLastCheck = 0f;
            }
        }
    }

    private void CheckMovementState()
    {
        bool wasMoving = isCurrentyMoving;
        isCurrentyMoving = movementDirection != Vector2.zero;
        
        if (wasMoving != isCurrentyMoving)
        {
            OnMovementStateChanged?.Invoke(isCurrentyMoving);
        }

        else if (isCurrentyMoving)
        {
            OnContinuousMovement?.Invoke();
        }
    }

    private void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }
}
