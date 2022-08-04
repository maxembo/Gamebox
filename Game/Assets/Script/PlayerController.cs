using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementCharacter character;

    [SerializeField] private Transform camera;

    private float inputH, inputV, run;

    private CharacterController controller;

    private Vector3 direction;

    private Quaternion look;

    private const float DICTANCE_OFFSET = 5f;

    private Vector3 TargetRotate => camera.forward * DICTANCE_OFFSET;

    private bool Idle => inputH == 0.0f && inputV == 0.0f;

    private Animator animator;

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

    private void PlayAnimation()
    {
        float horizontal = run * inputH + inputH;
        float vertical = run * inputV + inputV;

        animator.SetFloat("Vertical",inputV);
        animator.SetFloat("Horizontal",inputH);
    }
    
}
