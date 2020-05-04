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


    // Start is called before the first frame update
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
        StartCoroutine(finalizarAnimacao(20, CamIntro));
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
