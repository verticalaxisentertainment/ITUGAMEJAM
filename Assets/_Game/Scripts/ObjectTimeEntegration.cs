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
        GameObject[] Item = new GameObject[2];
        if(isHolding)
        {
            if(isFuture)
            {
            //    Item[0] = future.gameItem["ID"];
            //    Item[1] = past.gameItem["ID"];
            //    Item[1].transform.position = future.transform.position;
            }
            else
            {
                //Item[0] = future.gameItem["ID"];
                //Item[1] = past.gameItem["ID"];
                //Item[1].transform.position = future.transform.position;
            }
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
