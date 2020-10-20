using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  ClickSoundStart: MonoBehaviour
{
    private AudioSource click;

    private void Start()
    {
        click = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void OnClick()
    {
        click.PlayOneShot(click.clip);
    }
}
