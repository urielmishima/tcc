using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Transform player;
    private bool playerIsAlive = true;

    public UnityEvent playerDie;
    public UnityEvent playerRespawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerDie?.Invoke();
        }
    }

    public void die()
    {
        playerIsAlive = false;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void respawn()
    {
        playerIsAlive = true;
        Time.timeScale = 1f;
        player.position = checkpoint.transform.position;
        player.rotation = checkpoint.transform.rotation;
        gameOverUI.SetActive(false);
        playerRespawn?.Invoke();
    }

    public bool GetPlayerIsAlive()
    {
        return playerIsAlive;
    }
}
