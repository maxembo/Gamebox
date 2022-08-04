using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Characterstics",menuName ="MovementCharacteristics", order = 1)]
public class MovementCharacter : ScriptableObject
{
    [SerializeField] private bool visibleCursor = false;

    [SerializeField] private float movementSpeed = 1f;

    [SerializeField] private float runSpeed = 1.6f;


    [SerializeField] private float angulatSpeed = 150f;

    [SerializeField] private float gravity = 15f;

    [SerializeField] private float jumpForce = 7f;

    public bool VisibleCursor => visibleCursor;

    public float MovementSpeed => movementSpeed;
    public float RunSpeed => runSpeed;
    public float AngularSpeed => angulatSpeed;
    public float Gravity => gravity;
    public float JumpForce => jumpForce;

}

