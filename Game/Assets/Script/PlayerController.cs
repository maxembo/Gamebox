using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementCharacter character;

    [SerializeField] private Transform camera;
    
    [SerializeField] private Text score;


    private float inputH, inputV, run;

    private int countJump;

    private CharacterController controller;

    private Vector3 direction;

    private Quaternion look;

    private const float DICTANCE_OFFSET = 5f;

    private Vector3 TargetRotate => camera.forward * DICTANCE_OFFSET;

    private bool Idle => inputH == 0.0f && inputV == 0.0f;

    private Animator animator;

     private int coins = 0;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Cursor.visible = character.VisibleCursor;
        
    }

    private void Update()
    {
        Movement();
        PlayerRotate();
        
    }
    private void Movement()
    {
        if (controller.isGrounded)
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");

            run = Input.GetAxis("Run");

            direction = transform.TransformDirection(inputH,0,inputV).normalized;

            PlayAnimation();
            Jump();
        }
        else
        {
            DoubleJump();
        }
        
        direction.y -= character.Gravity * Time.deltaTime;
        
        float speed = run * character.RunSpeed + character.MovementSpeed;

        Vector3 dir = direction * speed * Time.deltaTime;

        dir.y = direction.y;

        controller.Move(dir);
    }

    private void PlayerRotate()
    {
        if (Idle) return;
        Vector3 target = TargetRotate;
        target.y = 0;

        look = Quaternion.LookRotation(target);

        float speed = character.AngularSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, speed);
    }

    private void Jump()
    {   
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
            direction.y += character.JumpForce;
            countJump++;
        }
        
    } 
   private void DoubleJump()
    {
        if(Input.GetButtonDown("Jump") && countJump > 0 && controller.isGrounded == false)
        {
            animator.SetTrigger("Jump");
            direction.y += character.DoubleJump;
            countJump--;
        }
    }
   
    private void PlayAnimation()
    {
        float horizontal = run * inputH + inputH;
        float vertical = run * inputV + inputV;

        animator.SetFloat("Vertical",vertical);
        animator.SetFloat("Horizontal",horizontal);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Money")
        {
            
            coins++;
            score.text = $"SCORE: {coins.ToString()}";
            Destroy(other.gameObject);
        }
    }
}
