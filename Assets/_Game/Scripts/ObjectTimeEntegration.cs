using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectTimeEntegration : MonoBehaviour
{
    private TimeMachineHandler timeMachineHandler;
    public bool isFuture = true;
    public Charachter charachter;
    public GameObject future;
    public GameObject past;

    void Start()
    {
        charachter = GameObject.FindGameObjectWithTag("Player").GetComponent<Charachter>();
        timeMachineHandler = TimeMachineHandler.Instance;
    }

    void Update()
    {
        ObjectEntegration(timeMachineHandler);
        //timeTravel();
    }

    void ObjectEntegration(TimeMachineHandler timeMachineHandler)
    {
        List<GameObject> pastList = getChilds(past);
        List<GameObject> futureList = getChilds(future);
        GameObject[] Items = new GameObject[2];
        int listIndex;
        if(timeMachineHandler.IsHolding())
        {
            if(isFuture)
            {
                Items[0] = timeMachineHandler.HoldedObject();

                foreach (GameObject o in futureList)
                {
                    if (Items[0] == o)
                    {
                        listIndex = futureList.IndexOf(o);
                        Items[1] = pastList[listIndex];
                    }
                }
                Debug.Log(Items[1].ToSafeString());
                Items[1].transform.position = new Vector3(future.transform.position.x,future.transform.position.y+102,future.transform.position.z);
            }
            else
            {
                //Item[0] = future.gameItem["ID"];
                //Item[1] = past.gameItem["ID"];
                //Item[1].transform.position = future.transform.position;
            }
        }
    }

    List<GameObject> getChilds(GameObject o)
    {
        List<GameObject> gs = new List<GameObject>();
        Transform[] ts = o.GetComponentsInChildren<Transform>();
        if (ts == null)
            return gs;
        foreach (Transform t in ts)
        {
            if (t != null && t.gameObject != null)
                gs.Add(t.gameObject);
        }
        return gs;
    }
}
