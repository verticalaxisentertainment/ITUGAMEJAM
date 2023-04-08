using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Charachter : MonoBehaviour
{
    private Rigidbody rigidbody;
    public Camera camera;
    public float moveSpeed = 3;
    private float speed;
    public float jumpStrength;
    public bool isGrounded;
   

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveRelativeToCamera();
    }

    void moveRelativeToCamera()
    {
        sprintNJumpLogic();

        // Input process
        float playerVertical = Input.GetAxis("Vertical");
        float playerHorizontal = Input.GetAxis("Horizontal");
        // Camera relativity and canceling  y camera axis for movement
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward = forward.normalized;
        right = right.normalized;

        // Moving player
       
        Vector3 move = forward * playerVertical + right * playerHorizontal;

        transform.position += move * speed * Time.deltaTime;
    }


    void sprintNJumpLogic()
    {
        //Sprinting logic
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = moveSpeed * 2;
        }
        else
        {
            speed = moveSpeed;
        }
        // Jump Logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            isGrounded = false;
        }

    }


    // Collision Related logics

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
