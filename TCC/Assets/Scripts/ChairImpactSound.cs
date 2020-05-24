using UnityEngine;

public class ChairImpactSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "cadeira3.0-color-rigidibody 1(Clone)")
        {
            audioSource.Play();
        }

    }
}
