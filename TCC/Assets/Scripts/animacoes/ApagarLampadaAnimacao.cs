using UnityEngine;

public class ApagarLampadaAnimacao : MonoBehaviour
{
    public Light lampada;
    public bool reacender = false;
    private float tempoUltimaPiscada; //tempo dês da ultima piscada :3
    //private float piscadasEntreTempo = 0.2f;

   

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "espectro")
        {
            lampada.enabled = true;
           
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "espectro")
        {
            lampada.enabled = reacender;
        }

    }
    /*
     
    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "espectro")
        {
            float pisca = Random.Range(0,1);
            if (tempoUltimaPiscada >= piscadasEntreTempo)
            {
                lampada.enabled = (pisca > 0.5);
            }
           
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "espectro")
        {
            lampada.enabled = reacender;
        }

    }

    private float contagemTempo()
    {
        if(tempoUltimaPiscada > piscadasEntreTempo)
        {
            tempoUltimaPiscada = 0;

        }
        tempoUltimaPiscada += Time.deltaTime;
        return tempoUltimaPiscada;
    }
    

     */


}
