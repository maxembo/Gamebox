using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSens = 200f;
    [SerializeField] private Transform player;
    
    private float mouseX;
    private float mouseY;


    private float xRotation = 0f;

    private Animator animator;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        player.Rotate(mouseX * new Vector3(0,1,0));

        transform.Rotate(mouseY * new Vector3(-1,0,0));

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(mouseY * new Vector3(-1, 0, 0));

       
    }

}
