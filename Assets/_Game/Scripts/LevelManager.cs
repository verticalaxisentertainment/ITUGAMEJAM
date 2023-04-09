using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject[] points;
    public GameObject HeadTarget, RightHandTarget;
    public LayerMask mask;

    public PostProcessVolume postProcessVolume;

    private LensDistortion lDistortion;
    private ChromaticAberration chromatic;
    private AutoExposure exposure;

    public CanvasGroup fadeCanvas,smokeCanvas;

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
            Cursor.visible = false;
        }
        if (SceneManager.GetActiveScene().name == "PastRoom")
        {
            StartCoroutine(StartMoving());
            Cursor.visible = false;
        }
    }

    public IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(11);
        HeadTarget.SetActive(true);
        RightHandTarget.SetActive(false);
        CameraManager.Instance.gameCam.Priority = 10000;
    }

    public IEnumerator Falling()
    {
        fadeCanvas.gameObject.GetComponentInChildren<RawImage>().color = Color.white;
        fadeCanvas.DOFade(0, 1.5f);
        yield return new WaitForSeconds(2);
        postProcessVolume.profile.TryGetSettings(out lDistortion);
        //falling = true;

        while (true)
        {
            lDistortion.intensity.Override(lDistortion.intensity - Time.deltaTime * 20);
            if (lDistortion.intensity <= -100.0f)
            {
                break;
            }
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForSeconds(1);
        while (true)
        {
            float temp = lDistortion.centerX;
            temp -= Time.deltaTime;
            lDistortion.centerX.Override(temp);
            if (lDistortion.centerX <= -1f)
                break;
            yield return new WaitForSeconds(0);
        }
        fadeCanvas.gameObject.GetComponentInChildren<RawImage>().color = Color.black;
        yield return fadeCanvas.DOFade(1, 5).WaitForCompletion();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        Cursor.visible = true;
    }

    public IEnumerator PushTheButton()
    {
        canSelect = false;
        yield return new WaitForSeconds(0.5f);
        CameraManager.Instance.gameCam.m_Lens.FieldOfView = 40;
        HeadTarget.transform.DOMove(new Vector3(points[5].transform.position.x, points[5].transform.position.y, points[5].transform.position.z + 0.5f), 1);
        yield return RightHandTarget.transform.DOMove(points[4].transform.position, 1).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
        RightHandTarget.transform.DORotate(new Vector3(107.8f, RightHandTarget.transform.rotation.y, RightHandTarget.transform.rotation.z), 1);
        yield return RightHandTarget.transform.DOMove(points[5].transform.position, 1).WaitForCompletion();
        CameraManager.Instance.gameCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.5f;
        postProcessVolume.profile.TryGetSettings(out chromatic);
        postProcessVolume.profile.TryGetSettings(out exposure);

        while (true)
        {
            chromatic.intensity.Override(1);
            exposure.maxLuminance.Override(exposure.maxLuminance - (Time.deltaTime * 50.0f));

            if (exposure.maxLuminance <= -8.7f)
                break;
            yield return new WaitForSeconds(0);
        }

        fadeCanvas.gameObject.GetComponentInChildren<RawImage>().color = Color.white;
        yield return fadeCanvas.DOFade(1, 3).WaitForCompletion();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        //if(falling)
        //{
        //    lDistortion.intensity.Override(lDistortion.intensity - Time.deltaTime * 20);
        //    if(lDistortion.intensity<=-100.0f)
        //    {
        //        lDistortion.centerX.Override(lDistortion.centerX - Time.deltaTime);
        //        fadeCanvas.DOFade(1, 5);
        //    }
        //}

        if (canSelect)
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, mask))
            {
                RightHandTarget.transform.DOMove(new Vector3(hitInfo.point.x+0.25f,hitInfo.point.y,hitInfo.point.z), 1);
            }
        }

        if (SceneManager.GetActiveScene().name == "Beginning")
        {
            if (TimeMachineHandler.Instance.mouseEntered)
                smokeCanvas.DOFade(1, 4);
            else
                smokeCanvas.DOFade(0, 1);
        }
    }
}
