using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BtnFX : MonoBehaviour
{
    public AudioSource BTNFX;
    public AudioClip ClickFX;
    public AudioClip[] HoverFx;

    public void ButtonEnter()
    {
        BTNFX.PlayOneShot(HoverFx[0]);
    }

    public void ButtonDown()
    {
        BTNFX.PlayOneShot(ClickFX);
    }

    public void ButtonExit()
    {
        BTNFX.PlayOneShot(HoverFx[1]);
    }
}
