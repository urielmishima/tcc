using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play() {
        StartCoroutine(ChangeScene());
    }

    public void Quit() {
        StartCoroutine(CloseScene());
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator CloseScene()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
  
}
