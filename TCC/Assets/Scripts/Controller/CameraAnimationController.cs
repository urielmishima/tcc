using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    public GameObject player;
    public GameObject CamIntro;
    public GameObject espectro;
    public GameObject trigger;
    public Animator animator;
    public GameObject pontoFinalizacaoEspectro;
    public GameObject portaBanheiro;
    public Animator portaAnimator;
    // Start is called before the first frame update
    void Start()
    {
        animator = CamIntro.GetComponent<Animator>();
        portaAnimator = portaBanheiro.GetComponent<Animator>();
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
        //player.transform.rotation = pontoFinalizacao.transform.rotation;
       // player.transform.Rotate(0.0f, 0.0f, 180.0f, Space.World);
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
        //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaa");
        CamIntro.SetActive(true);
        espectro.SetActive(true);
        player.SetActive(false);
        animator.SetTrigger("espectro_start");
        StartCoroutine(finalizarAnimacaoEspectro(25, CamIntro, pontoFinalizacaoEspectro));
        portaAnimator.SetTrigger("PortaBanheiroTrigger");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            espectroAnimation();
        }
    }
}
