using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TimeMachineHandler : MonoBehaviour
{
    public static TimeMachineHandler Instance;

    public float maxGrabDistance = 10.0f, throwForce = 20f, lerpTime = 10f;
    public LineRenderer lineRenderer;
    public Transform objectHolder, topofTheMacghine;

    Rigidbody grabbedRB;

    public bool grounded = false;
    bool mouseEntered = false;

    private Vector3 velocity;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
    }

    void Update()
    {
        if (mouseEntered && Input.GetMouseButtonDown(0))
        {
            Debug.Log("basto");
        }
        //Input.mousePosition.Set(0, 0, 0);
        if(!mouseEntered&&Input.GetMouseButtonDown(0))
        {
            if (!grabbedRB)
            {
                lineRenderer.enabled = true;
                RaycastHit hit;
                if (Physics.Raycast(UnityEngine.Camera.main.transform.position, UnityEngine.Camera.main.transform.forward, out hit, float.MaxValue))
                {
                    if (hit.rigidbody&&hit.rigidbody.CompareTag("Movable"))
                    {
                        Debug.Log("var");
                        grabbedRB = hit.rigidbody;
                        grabbedRB.isKinematic = false;
                        grabbedRB.useGravity = false;
                    }
                }
            }
            else
            {
                grabbedRB.useGravity = true;
                velocity = objectHolder.position - grabbedRB.position;
                grabbedRB.velocity = velocity * 5;
                grabbedRB = null;
                lineRenderer.enabled = false;
            }
        }
        
        



       
    }

    public GameObject HoldedObject()
    {
        if (grabbedRB)
            return grabbedRB.gameObject;
        else
            return null;
    }

    public bool IsHolding()
    {
        if (grabbedRB)
            return true;
        else
            return false;
    }

    private void LateUpdate()
    { 
        lineRenderer.SetPosition(0, topofTheMacghine.position);
        if (grabbedRB)
        {
            lineRenderer.enabled = true;
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.position, Time.deltaTime * lerpTime));
            //grabbedRB.DOMove(objectHolder.transform.position, lerpTime);
            lineRenderer.SetPosition(1, grabbedRB.transform.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void OnMouseEnter()
    {
        mouseEntered = true;
    }

    private void OnMouseExit()
    {
        mouseEntered = false;
    }
}
