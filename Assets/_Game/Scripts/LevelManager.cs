using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] points;
    public static LevelManager instance;
    public GameObject HeadTarget, RightHandTarget;
    public LayerMask mask;

    public PostProcessVolume postProcessVolume;
    private LensDistortion lDistortion;

    public CanvasGroup fadeCanvas;

    bool falling = false, canSelect = false;
    private void Awake()
    {
       instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Falling")
        {
            StartCoroutine(Falling());
        }
    }

    public IEnumerator Falling()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("çalýþýyor");
        postProcessVolume.profile.TryGetSettings(out lDistortion);
        falling = true;
    }

    public IEnumerator StartCinematic()
    {
        yield return HeadTarget.transform.DOMove(points[0].transform.position, 2).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
        yield return HeadTarget.transform.DOMove(points[1].transform.position, 2).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
        yield return HeadTarget.transform.DOMove(points[2].transform.position, 2).WaitForCompletion();
        yield return HeadTarget.transform.DOMove(points[3].transform.position, 2).WaitForCompletion();
        canSelect = true;
    }

    private void Update()
    {
        if(falling)
        {
            lDistortion.intensity.Override(lDistortion.intensity - Time.deltaTime*20);
            if(lDistortion.intensity<=-100.0f)
            {
                lDistortion.centerX.Override(lDistortion.centerX - Time.deltaTime);
                fadeCanvas.DOFade(1, 5);
            }
        }

        if (canSelect)
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, mask))
            {
                RightHandTarget.transform.DOMove(new Vector3(hitInfo.point.x+0.25f,hitInfo.point.y,hitInfo.point.z), 1);
            }
        }
    }
}
