using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]

public class M011_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void AnimationChangeHandler(int animator, string animationName);
    public static event AnimationChangeHandler OnAnimationChange;

    private static Vector2 _input;

    private static Vector3 _direction;

    private static Vector3 _directionMala;

    private static Vector3 _directionGrav;
    private static CharacterController _characterController;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;

    [SerializeField] private Movement movement;

    private float _velocity;

    [SerializeField] private float speed;

    [SerializeField] private float smoothTime = 0.05f;

    [SerializeField] private float jumpPower;

    public bool isJumping;

    private float _currentVelocity;

    public Animator animator;



    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();


    }

    public void Move(InputAction.CallbackContext context)
    {



        _input = context.ReadValue<Vector2>();


        _directionMala = new Vector3(_input.x, y: 0.0f, z: _input.y);

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        _direction = matrix.MultiplyPoint3x4(_directionMala);









    }



    private void ApplyMovement()
    {

        var targetSpeed = movement.isSprinting ? movement.speed * movement.multiplier : movement.speed;

        movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.acceleration * Time.deltaTime);

        _characterController.Move(_direction * movement.currentSpeed * Time.deltaTime);

        if (IsGrounded() && movement.isSprinting == false)
        {

            movement.currentSpeed = 10f;

            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            _direction = matrix.MultiplyPoint3x4(_directionMala);
        }

        if (IsGrounded() && movement.isSprinting == true)
        {
            movement.currentSpeed = 17f;

            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            _direction = matrix.MultiplyPoint3x4(_directionMala);
        }


        if (!IsGrounded())
        {

            _direction = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.forward;

        }


    }


    public void Jump(InputAction.CallbackContext context)
    {

        if (GameManager.Instance.NivelDeCarga >= 2)
        {
            if (!context.started) return;
            if (!IsGrounded()) return;

            _velocity = jumpPower / 2;

            if (!movement.isSprinting)
            {
                movement.currentSpeed = movement.currentSpeed * 2f;
            }

            if (movement.isSprinting == true)
            {
                movement.currentSpeed = movement.currentSpeed * 2f;
            }

            _direction = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.forward;

            cantidadSaltos += 1;

            //animator.Play("Jump1");

            isJumping = true;

          

            //Salto = true;

            CheckJump();


        }



    }

    public void CheckJump()
    {
        if (cantidadSaltos == 3 && isJumping == true && GameManager.Instance.NivelDeCarga >= 2)
        {
            GameManager.Instance.DisminuirNivelDeCargaPorSalto();

            //Salto = false;

            cantidadSaltos = 0;

        }

    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;

            gravityMultiplier = 1.2f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;

        }
        _direction.y = _velocity;


    }

    public void AnimationChanges()
    {
        if (_direction == Vector3.zero)
        {

            OnAnimationChange?.Invoke(0, "Cadenas_Stop");

        }
        if(movement.currentSpeed == 10)
        {
            OnAnimationChange?.Invoke(0, "Cadenas_Idle");

        }
        if(movement.currentSpeed == 17)
        {
            OnAnimationChange?.Invoke(0, "Sprint");

        }
        if(isJumping == true)
        {
            OnAnimationChange?.Invoke(2 , "Jump");
        }
        if(IsReparing == true)
        {
            OnAnimationChange?.Invoke(2 , "Fix");
        }
        
       


    }

    void Update()
    {
        AnimationChanges();

        ApplyGravity();

        ApplyRotation();

        ApplyMovement();

        //print(isJumping);

        if (IsGrounded())
        {
            isJumping = false;
        }

        

        


        if (movement.isSprinting == true)
        {

            GameManager.Instance.DisminuirCooldown();


            // Debug.Log(GameManager.Instance.RemainingSprintTime);


        }
        if (GameManager.Instance.RemainingSprintTime == 0f && movement.isSprinting == true)
        {
            //movement.isSprinting = false;

            movement.isSprinting = false;

        }


    }


    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!movement.isSprinting && GameManager.Instance.RemainingSprintTime > 0f)
            {

                movement.isSprinting = true;


                if (GameManager.Instance.RemainingSprintTime == 5f)
                {
                    GameManager.Instance.DisminuirNivelDeCarga();

                }


            }
            else if (movement.isSprinting)
            {


                movement.isSprinting = false;



            }

        }

    }

    private bool IsReparing;



     public void Pick(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            IsReparing = true;

            GameManager.Instance.Repear();
            print("hola");
        }
        else
        {
            IsReparing = false;

        }
    }


    private void ApplyRotation()
    {

        if (IsGrounded())
        {
            if (_input.sqrMagnitude == 0) return;

            var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;

            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);

            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z);


        }



    }

    public float extraJumpForce;

    public int cantidadSaltos;

    //public bool Salto;







    private bool IsGrounded() => _characterController.isGrounded;

    public float timeSprint = 0.0f;

    public bool StartCooldown;





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
