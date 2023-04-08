using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Charachter : MonoBehaviour
{
    private CharacterController characterController;
    public Camera camera;
    public float speed;
   

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveRelativeToCamera();
    }

    void moveRelativeToCamera()
    {
        float playerVertical = Input.GetAxis("Vertical");
        float playerHorizontal = Input.GetAxis("Horizontal");
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 move = forward * playerVertical + right * playerHorizontal;
        characterController.Move(move * speed * Time.deltaTime);
    }

    
}
