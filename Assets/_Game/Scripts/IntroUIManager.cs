using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroUIManager : MonoBehaviour
{
    public TMP_Text introText;
    public CanvasGroup canvasGroup;

    void Start()
    {
        //introText.color=new Color(introText.color.r, introText.color.g,introText.color.b,0.0f);
        StartCoroutine(StartText());
    }


    IEnumerator StartText()
    {
        yield return new WaitForSeconds(1);
        introText.DOFade(1, 3);
        yield return new WaitForSeconds(3);
        yield return introText.DOFade(0, 3).WaitForCompletion();
        canvasGroup.DOFade(0, 5);
        yield return new WaitForSeconds(1);
        StartCoroutine(LevelManager.instance.StartCinematic());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StopCoroutine(StartText());
            canvasGroup.alpha = 0;
            
        }
    }
}
