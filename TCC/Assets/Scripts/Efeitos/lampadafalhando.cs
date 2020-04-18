using System.Collections;
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
        float currentLightIntensity = this.light.intensity;

        this.light.intensity = value;

        if (value <= 2.8 && currentLightIntensity > value && !this.audioSource.isPlaying)
        {
            this.audioSource.Play();
        }
    }

    void fixedUpdate()
    {   

    }
}
