using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Characterstics",menuName ="MovementCharacteristics", order = 1)]
public class MovementCharacter : ScriptableObject
{
    [SerializeField] private bool visibleCursor = false;

    [SerializeField] private float movementSpeed = 1f;

    [SerializeField] private float runSpeed = 2.5f;


    [SerializeField] private float angulatSpeed = 150f;

    [SerializeField] private float gravity = 15f;

    [SerializeField] private float jumpForce = 7f;

    [SerializeField] private float doubleJump = 5f;

    public bool VisibleCursor => visibleCursor;

    public float MovementSpeed => movementSpeed;
    public float RunSpeed => runSpeed;
    public float AngularSpeed => angulatSpeed;
    public float Gravity => gravity/10;
    public float JumpForce => jumpForce/ 100f;
    public float DoubleJump => doubleJump/ 100f;

}

