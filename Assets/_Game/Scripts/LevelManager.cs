using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] points;
    public static LevelManager instance;
    public GameObject HeadTarget,RightHandTarget;
    public LayerMask mask;

    private void Awake()
    {
       instance = this;
    }
    
    public IEnumerator StartCinematic()
    {
        yield return HeadTarget.transform.DOMove(points[0].transform.position, 2).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
        yield return HeadTarget.transform.DOMove(points[1].transform.position, 2).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
        yield return HeadTarget.transform.DOMove(points[2].transform.position, 2).WaitForCompletion();
        yield return HeadTarget.transform.DOMove(points[3].transform.position, 2).WaitForCompletion();
    }

    private void Update()
    {
        //if (false)
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, mask))
            {
                RightHandTarget.transform.position = hitInfo.point;
            }
        }
    }
}
