using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    public GameObject player;
    public GameObject CamIntro;

    // Start is called before the first frame update
    void Start()
    {
        introAnimation();
    }

  
    IEnumerator finalizarAnimacao(int secs, GameObject camera)
    {
        yield return new WaitForSeconds(secs);
        player.SetActive(true);
        camera.SetActive(false);
    }

    void introAnimation()
    {
        CamIntro.SetActive(true);
        player.SetActive(false);
        StartCoroutine(finalizarAnimacao(8, CamIntro));
    }
}
