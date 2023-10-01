using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class M011_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private static Vector2 _input;

    private static Vector3 _direction;
    private static CharacterController _characterController;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;

    [SerializeField] private Movement movement;

    private float _velocity;

    [SerializeField] private float speed;

    [SerializeField] private float smoothTime = 0.05f;

    [SerializeField] private float jumpPower;

    private float _currentVelocity;

    

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();

        Debug.Log(_input);

        _direction = new Vector3(_input.x, y: 0.0f, z: _input.y);
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ApplyGravity();

        ApplyRotation();

        ApplyMovement();

      

      
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;

        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);

        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);


    }

    private void ApplyMovement()
    {
        var targetSpeed = movement.isSprinting ? movement.speed * movement.multiplier : movement.speed;

        movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.acceleration * Time.deltaTime);
        _characterController.Move(_direction * movement.currentSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;

        }
        _direction.y = _velocity;


    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded()) return;

        _velocity += jumpPower;
    }

    private bool IsGrounded() => _characterController.isGrounded;

    public void Sprint(InputAction.CallbackContext context)
    {
        movement.isSprinting = context.started || context.performed; // started al pulsar performed al dejar pulsado
    }


    private bool eKeyIsPressed = false;

    public void Epressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            eKeyIsPressed = true;
            GameManager.Instance.SetEKeyPressed(true);
            Debug.Log("E PULSADA");
        }
        else if (context.canceled)
        {
            eKeyIsPressed = false;
            GameManager.Instance.SetEKeyPressed(false);
        }
    }

    private bool adherido = false;

    public GameObject cubo;


    public void InteractuarPress(InputAction.CallbackContext context)
    {

        if (context.started)

        {

            if (!adherido)
            {
                // Mueve el cubo justo delante del personaje y lo convierte en un hijo del personaje.
                cubo.transform.position = transform.position + transform.forward * 1.0f;
                cubo.transform.SetParent(transform);

                
                cubo.transform.rotation = Quaternion.Euler(0f,0f,0f);
                adherido = true;
            }
            else
            {
                // Desvincula el cubo del personaje.
                
                cubo.transform.SetParent(null);
                cubo.transform.rotation = Quaternion.Euler(0f,0f,0f);
                adherido = false;
            }

        }

    }



}

[System.Serializable]
public struct Movement
{
    public float speed;
    public float multiplier;

    public float acceleration;
    public bool isSprinting;

    public float currentSpeed;
}
