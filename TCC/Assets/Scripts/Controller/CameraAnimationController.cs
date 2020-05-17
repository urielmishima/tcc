using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraAnimationController : MonoBehaviour
{
    public GameObject player;
    public GameObject CamIntro;
    public GameObject espectro;
    public GameObject trigger;
    public Animator animator;
    public GameObject pontoFinalizacaoEspectro;
    public Animator portaAnimator;

    private int doorOpenAttempts;
    public UnityEvent firstOpenTry;

    void Start()
    {
        animator = CamIntro.GetComponent<Animator>();
        introAnimation();
    }
  
    IEnumerator finalizarAnimacao(int secs, GameObject camera)
    {
        yield return new WaitForSeconds(secs);
        player.SetActive(true);
        camera.SetActive(false);
    }
    IEnumerator finalizarAnimacaoEspectro(int secs, GameObject camera, GameObject pontoFinalizacao)
    {
        yield return new WaitForSeconds(secs);
        player.SetActive(true);
        player.transform.position = camera.transform.position;
        camera.SetActive(false);
    }
    void introAnimation()
    {
        CamIntro.SetActive(true);
        player.SetActive(false);
        StartCoroutine(finalizarAnimacao(8, CamIntro));
    }

    public void espectroAnimation()
    {
        if (doorOpenAttempts == 1)
        {
            CamIntro.SetActive(true);
            espectro.SetActive(true);
            player.SetActive(false);
            animator.SetTrigger("espectro_start");
            StartCoroutine(finalizarAnimacaoEspectro(25, CamIntro, pontoFinalizacaoEspectro));
        } else if (doorOpenAttempts == 0)
        {
            firstOpenTry?.Invoke();
        }
        doorOpenAttempts++;
    }
}
