﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoSala : MonoBehaviour
{
    public GameObject ponto;
    private Animator animator;
    public GameObject bloqueioPorta;


    //parametros de explosão
    public float poder = 15.0f;
    public float raio = 15.0f;
    public float upforce = 1.0f;
    public float tempoAnimacao = 4f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("matar");
            Invoke("pulso", tempoAnimacao);
            Invoke("destruirBloqueio", tempoAnimacao);
        }
    }

    void pulso()
    {
        Vector3 posisaoPulso = ponto.transform.position;
        Collider [] colliders = Physics.OverlapSphere(posisaoPulso, raio);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(poder, posisaoPulso, raio, upforce, ForceMode.Impulse);
        }
    }
    void destruirBloqueio()
    {
        Destroy(this.bloqueioPorta);
    }
}
