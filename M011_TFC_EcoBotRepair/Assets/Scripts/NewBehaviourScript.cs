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

    private static Vector3 _directionMala;
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

        //SprintCooldown();

    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();

        //Debug.Log(_input);

        _directionMala = new Vector3(_input.x, y: 0.0f, z: _input.y);

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        _direction = matrix.MultiplyPoint3x4(_directionMala);



    }



    // Update is called once per frame
    void Update()
    {

        ApplyGravity();

        ApplyRotation();

        ApplyMovement();




        // if (isSprinting)
        // {
        //     timeSprint += Time.deltaTime;

        //     if(timeSprint >= 10.0f && isSprinting == true)
        //     {
        //         GameManager.Instance.DisminuirNivelDeCarga();

        //         timeSprint = 0f;

        //         isSprinting = false;

        //         movement.isSprinting = false;





        //     }

        //     if(!isSprinting)
        //     {
        //         timeSprint = 0f;

        //     }

        // }




        if (isSprinting == true)
        {

            GameManager.Instance.DisminuirCooldown();


            Debug.Log(GameManager.Instance.RemainingSprintTime);


        }
        if (GameManager.Instance.RemainingSprintTime == 0f && isSprinting == true)
        {



            GameManager.Instance.DisminuirNivelDeCarga();

            isSprinting = false;

            movement.isSprinting = false;



        }







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

            gravityMultiplier = 1.2f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;

        }
        _direction.y = _velocity;



    }

    public float extraJumpForce;

    public int cantidadSaltos;

    public bool Salto;

    public void Jump(InputAction.CallbackContext context)

    {

        if (GameManager.Instance.NivelDeCarga >= 2)
        {
            if (!context.started) return;
            if (!IsGrounded()) return;

            _velocity += jumpPower;

            cantidadSaltos += 1;
            Salto = true;

            CheckJump();






        }

    }

    public void CheckJump()
    {
        if (cantidadSaltos == 3 && Salto == true && GameManager.Instance.NivelDeCarga >= 2)
        {


            GameManager.Instance.DisminuirNivelDeCarga();
            

            Salto = false;

            cantidadSaltos = 0;



        }

    }



    public float gravityReduction;

    public bool superSalto;

    public void SuperSalto(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.NivelDeCarga == 4)
        {
            if (!context.started) return;
            if (!IsGrounded()) return;


            GameManager.Instance.DisminuirNivelDeCarga();
            




        }


    }



    private bool IsGrounded() => _characterController.isGrounded;

    public float timeSprint = 0.0f;
    public bool isSprinting = false;








    // public void SprintCooldown()
    // {
    //     remainingSprintTime = totalSprintTime;
    // }


    public bool StartCooldown;



    public void Sprint(InputAction.CallbackContext context)
    {

        if (GameManager.Instance.RemainingSprintTime > 0f && GameManager.Instance.NivelDeCarga >= 3)
        {
            if (context.started || context.performed)
            {

                isSprinting = true;
                movement.isSprinting = true;

                //Debug.Log(GameManager.Instance.TotalSprintTime);

            }





        }

        if (context.canceled)
        {
            isSprinting = false;
            movement.isSprinting = false;

        }





    }






    private bool adherido = false;

    public GameObject cubo;

    


    public void ArrastrarObj(InputAction.CallbackContext context)
    {

        if (context.started && adherible)

        {

            if (!adherido)
            {
                // Mueve el cubo justo delante del personaje y lo convierte en un hijo del personaje.
                cubo.transform.position = transform.position + transform.forward * -1.0f;
                 cubo.transform.SetParent(transform);


                cubo.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                adherido = true;
            }
            else
            {
                // Desvincula el cubo del personaje.

                cubo.transform.SetParent(null);
               cubo.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                adherido = false;
            }

        }

    }

    private bool adherible;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            cubo = other.gameObject;
            adherible = true;
        }

    }

     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            cubo = null;
            adherible = false;
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
