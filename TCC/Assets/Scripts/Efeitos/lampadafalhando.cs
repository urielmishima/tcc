﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampadafalhando : MonoBehaviour
{
    public new Light light;
    public GameObject emissiveObject;
    public AudioSource audioSource;
    public AnimationCurve animationCurve;
    public WrapMode wrapmode = WrapMode.PingPong;

    void start()
    {
        this.animationCurve.postWrapMode = this.wrapmode;
    }

        void Update()
    {
        float value = animationCurve.Evaluate(Time.time);

        this.light.intensity = value;
    }
}
