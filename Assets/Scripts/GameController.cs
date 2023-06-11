using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int numberCollectibles;
    public GameObject endMessage;

    public GameObject PauseMenu;
    private bool isPaused;
    public GameObject WinMenu;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        player = GameObject.Find("Player").GetComponent<Player>();
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canPlay == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //se quer parar o jogo
                if (!isPaused)
                {
                    PauseGame();
                }
                //se já está em pausa
                else
                {
                    ResumeGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        player.canPlay = false;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        player.canPlay = true;
    }

    public void WinGame()
    {
        player.WinCutscene();
        WinMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LeaveGame()
    {
        GoToMainMenu();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("menuScene");
    }
}
