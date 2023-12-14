using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

//[RequireComponent(typeof(CharacterController))]

public class M011_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void AnimationChangeHandler(int animator, string animationName);
    public static event AnimationChangeHandler OnAnimationChange;

    

    public delegate void ParticleChangeHandler(int particleSystem, bool play);
    public static event ParticleChangeHandler OnParticleChange;

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

    private void Start()
    {
        

        //StartCoroutine("Starting");

        Deshabilitar();

        _directionMala = new Vector3(0f , 0 , -1.4f );

        //DOTween.To(()=> _directionMala , x=> _directionMala = x, new Vector3(0,0,0), 4f);

        Invoke("Habilitar", 2f);


        

        //OnDisable();
    }

  

    void OnEnable()
    {
       
    }

    private void Habilitar()
    {
         InputManager.OnJumpingChange += Jump;

       

         InputManager.OnRepairingChange += Repair;

         InputManager.OnSpritingChange += Sprint;

        InputManager.OnMovementChange += Move;

       

        InputManager.OnSuperingChange += SuperSalto;

        Death.OnKillChange += Killed;

        Laser.OnLaserHit += Killed;

        NextLevelSpaceship.OnLevelEndChange += NotPlaying;

        
         _directionMala = new Vector3(0 , 0 ,0);
         


    }

    private void Deshabilitar()
    {
         InputManager.OnJumpingChange -= Jump;

         InputManager.OnRepairingChange -= Repair;

         InputManager.OnSpritingChange -= Sprint;

        InputManager.OnMovementChange -= Move;

        InputManager.OnSuperingChange -= SuperSalto;

        Death.OnKillChange -= Killed;

        Laser.OnLaserHit -= Killed;

        NextLevelSpaceship.OnLevelEndChange -= NotPlaying;
         

    }

 
    
     

    

        void OnDisable()
    {
        //      InputManager.OnMovementChange -= Move;

        //  InputManager.OnJumpingChange -= Jump;

        //  InputManager.OnRepairingChange -= Repair;

        //  InputManager.OnSpritingChange -= Sprint;

    }

    private void NotPlaying()
    {
        gameObject.SetActive(false);

    }

    private void Killed()
    {   
           //Scene_Manager.Instance.LoadLevel1();

           gameObject.tag = "Untagged";

           Deshabilitar();


           

        

           OnAnimationChange?.Invoke(2, "Death");

           _directionMala = Vector3.zero;

            
            StartCoroutine("Respawn");

    }

    private IEnumerator Respawn()
    {
        GameManager.Instance.ReducirCooldown();

        movement.isSprinting = false;
        
        yield return new WaitForSeconds(1.5f);
        
        
        LevelManager.Instance.Respawn();

        gameObject.tag = "Player";

        Habilitar();



    }


  

    


    

    public void Move(Vector2 input)
    {
        //print(input);
        
            _input = input;

        //_input = context.ReadValue<Vector2>();



        _directionMala = new Vector3(_input.x, y: 0.0f, z: _input.y);

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        if(IsGrounded() == true)
        {
             _direction = matrix.MultiplyPoint3x4(_directionMala);

        }
        else
        {
             _direction = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.forward;

        }

       

        

        



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

    



    }


    public void Jump()
    {

        if (GameManager.Instance.NivelDeCarga >= 2)
        {
            //if (!context.started) return;

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

    public void SuperSalto()
    {
        print("hola");

        if(GameManager.Instance.NivelDeCarga == 4)
        {
             if (!IsGrounded()) return;

            _velocity = jumpPower * 2;

            //GameManager.Instance.DisminuirNivelDeCarga();
            //GameManager.Instance.DisminuirNivelDeCarga();
            //GameManager.Instance.DisminuirNivelDeCarga();

            OnAnimationChange?.Invoke(2 , "Jump2");

            GameManager.Instance.DisminuirNivelDeCarga();
            GameManager.Instance.DisminuirNivelDeCarga();
            GameManager.Instance.DisminuirNivelDeCarga();



        }
    }

    public void CheckJump()
    {
        if (cantidadSaltos == 3 && isJumping == true && GameManager.Instance.NivelDeCarga >= 2)
        {
            //print(cantidadSaltos);

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

    public float timeFalling;

    private bool CanDie;

    private void FallDamage()
    {
        

        if(_direction.y < 0 )
        {
            timeFalling += Time.deltaTime;
            
        }
        if(timeFalling > 0.72f)
        {
            //Killed();
            CanDie = true;

      
        }
        if(IsGrounded() && !CanDie)
        {
            timeFalling = 0;
        }
        if(CanDie && IsGrounded())
        {
            Killed();
           
             CanDie = false;
            timeFalling = 0;

        }
    }

    public void AnimationChanges()
    {
        if (_direction != Vector3.zero)
        {
            //AudioManager.instance.PlaySound("robot_walk");
            OnParticleChange?.Invoke(0, true );
            

        }
        if (_direction == Vector3.zero)
        {
            OnAnimationChange?.Invoke(0, "Cadenas_Stop");
            OnParticleChange?.Invoke(0, false );

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
            OnParticleChange?.Invoke(2, true );

             
        }
         if(isJumping == false)
        {
           
             OnParticleChange?.Invoke(2, false );

             
        }
        

        if(IsReparing == true)
        {
            OnAnimationChange?.Invoke(2 , "Fix");
            OnParticleChange?.Invoke(3, true );

        }
        if(IsReparing == false)
        {
            
            OnParticleChange?.Invoke(3 , false );

        }
        
    

    }


    void Update()
    {
        //print(_direction.y);
        //print(_directionMala);
        FallDamage();
        
        
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
        // if (GameManager.Instance.RemainingSprintTime == 0f && movement.isSprinting == true)
        // {
        //     //movement.isSprinting = false;

        //     movement.isSprinting = false;

        // }


    }


    public void Sprint()
    {
        print("probando sprint");
        
             if (!movement.isSprinting && GameManager.Instance.RemainingSprintTime > 0f)
             {

                movement.isSprinting = true;


             if (GameManager.Instance.RemainingSprintTime == 5f && GameManager.Instance.NivelDeCarga == 3)
                  {
                    print("hola");

                     GameManager.Instance.DisminuirNivelDeCarga();

               }


             }
             else if (movement.isSprinting)
            {


                movement.isSprinting = false;



            }

         

    }

    private bool IsReparing;



     public void Repair(bool reparando)
    {
        
        if (reparando == true)
        {
            IsReparing = true;

            GameManager.Instance.Repear();
            
        }
        if(reparando == false)
        {
            GameManager.Instance.NotRepear();
             IsReparing = false;

        }

        
        
    }


    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        if (IsGrounded() && !isJumping)
        {
            

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
