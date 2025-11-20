using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Canvas inputCanvas;
    [SerializeField] bool isJoystick;

    public float movementSpeed;

    // Добавляем кэшированные векторы для оптимизации 
    private Vector2 movementDirection;
    private Vector2 newVelocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        EnableJoystickInput();
    }

    private void FixedUpdate()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector2(joystick.Direction.x, joystick.Direction.y);
            
            newVelocity.x = movementDirection.x * movementSpeed;
            newVelocity.y = movementDirection.y * movementSpeed;
            _rigidbody.velocity = newVelocity;
        }
    }

    private void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }
    
    
}
