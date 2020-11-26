using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : IInteractable
{

    [SerializeField] private GameObject player;
    private bool playerEnter;
    private AudioSource audioLocked;

    void Start()
    {
        GUIText = "interact";
        SceneManager.sceneLoaded += SceneLoaded;
        audioLocked = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var activeScene = ("Sala" == SceneManager.GetActiveScene().name);
        if (!activeScene) OnEndLook();
        player.SetActive(activeScene);
    }

    public override void OnStartLook()
    {
        ShowText = true;
    }
    public override void OnInteract()
    {
        if (playerEnter) audioLocked.Play();
        else {
            playerEnter = true;
            SceneManager.LoadScene("Capela", LoadSceneMode.Additive);
        }

    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    public void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}
