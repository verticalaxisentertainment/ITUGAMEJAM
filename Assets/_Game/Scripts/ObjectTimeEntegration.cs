using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectTimeEntegration : MonoBehaviour
{
    public bool isFuture = true;
    public Charachter charachter;
    public GameObject future;
    public GameObject past;

    void Start()
    {
        charachter = GameObject.FindGameObjectWithTag("Player").GetComponent<Charachter>();
    }

    void Update()
    {
        //ObjectEntegration(true);
        //timeTravel();
    }

    void ObjectEntegration(bool isHolding/* , script's class type - item*/)
    {
        if(isHolding)
        {
            if(isFuture)
            {

            }
            //Get and put two same ID'ed objects into array
            //Check if there is more than 2 same ID'ed object
            //If yes abort
            //else set the x and z coordinates  of two object same

        }
    }

    //void timeTravel()
    //{
    //    if (Input.GetKeyDown(KeyCode.Tab))
    //    {
    //        if (isFuture)
    //        {
    //            transform.position = new Vector3(transform.position.x,101.5f,transform.position.z);
    //            isFuture = false;
    //        }
    //        else
    //        {
    //            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
    //            isFuture = true;
    //        }
    //    }
    //}
}
