using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject TimerController;

    public GameObject PauseMenu;
    private bool isPaused;
    public GameObject WinMenu;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        player = GameObject.Find("Player").GetComponent<Player>();
        PauseMenu.SetActive(false);
        TimerController.GetComponent<TimerController>().StartTimer();
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
        TimerController.GetComponent<TimerController>().PauseTimer();
        PauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        player.canPlay = false;
        player.camera.canLook = false;
    }

    public void ResumeGame()
    {
        TimerController.GetComponent<TimerController>().ResumeTimer();
        PauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        player.canPlay = true;
        player.camera.canLook = true;
    }

    public void WinGame()
    {
        TimerController.GetComponent<TimerController>().PauseTimer();
        player.WinCutscene();
        WinMenu.SetActive(true);
    }

    public void RestartGame()
    {
        
        TimerController.GetComponent<TimerController>().StartTimer();
        SceneManager.LoadScene("SampleScene");
    }

    public void LeaveGame()
    {
        TimerController.GetComponent<TimerController>().PauseTimer();
        GoToMainMenu();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("menuScene");
    }
}
