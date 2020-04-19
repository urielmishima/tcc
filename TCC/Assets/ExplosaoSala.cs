using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoSala : MonoBehaviour
{
    public GameObject ponto;
    private Animator animator;
    public GameObject bloqueioPorta;
    [SerializeField] private AudioClip pulseSound;
    private AudioSource audioSource;


    //parametros de explosão
    public float poder = 15.0f;
    public float raio = 15.0f;
    public float upforce = 1.0f;
    public float tempoAnimacao = 4f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Init()
    {
        animator.SetTrigger("matar");
        Invoke("pulso", tempoAnimacao);
        Invoke("destruirBloqueio", tempoAnimacao);
    }

    void pulso()
    {
        Vector3 posisaoPulso = ponto.transform.position;
        Collider [] colliders = Physics.OverlapSphere(posisaoPulso, raio);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(poder, posisaoPulso, raio, upforce, ForceMode.Impulse);
                audioSource.PlayOneShot(pulseSound);
            }
        }
    }
    void destruirBloqueio()
    {
        Destroy(this.bloqueioPorta);
    }
}
