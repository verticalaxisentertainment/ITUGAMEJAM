using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Movable"))
        {
            TimeMachineHandler.Instance.grounded = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Movable"))
        {
            TimeMachineHandler.Instance.grounded = false;
        }
    }
}
