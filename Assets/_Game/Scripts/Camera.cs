using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject parent;
    public float cameraSpeed = 5;
    float yaw = 0;
    float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
    }

    
    void moveCamera()
    {
        yaw += Input.GetAxis("Mouse X") * cameraSpeed;
        pitch -= Input.GetAxis("Mouse Y") * cameraSpeed;

        if(pitch > 82.000001)
        {
            pitch = 82;
        }
        else if(pitch < -82.000001)
        {
            pitch = -82;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        parent.transform.eulerAngles = new Vector3(0f,yaw,0f);
    }
}
