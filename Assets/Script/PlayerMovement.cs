using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Attach this to Player
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject cam;

    Vector2 rotation = Vector2.zero;
    public float sensitivity = 10f;
    public string xAxis = "Mouse X";
    public string yAxis = "Mouse Y";


    public float moveSpeed;


    public Vector3 slideScale;
    public Vector3 normalScale;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        slideScale = new Vector3(1, 0.5f, 1);
        normalScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = rb.velocity;

        // Should be cross platform movement
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveDirection = m_Input;
        moveDirection = transform.TransformDirection(moveDirection);

        rb.velocity = (moveDirection * moveSpeed);



        // TO-DO: Sliding

        if (Input.GetMouseButtonDown(0)) { 
        // Camera Rotation
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat;
            }

    }
  
}