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
        if (!player.wonGame)
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

            //se está a carregar no botão do rato para olhar à volta
            if (Input.GetMouseButton(0))
            {
                PausePhysics();
            }
            else if (!isPaused)
            {
                ResumePhysics();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        isPaused = true;
        player.camera.canLook = false;
        PausePhysics();
    }

    private void PausePhysics()
    {
        TimerController.GetComponent<TimerController>().PauseTimer();
        Time.timeScale = 0;
        player.canPlay = false;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
        player.camera.canLook = true;
        ResumePhysics();
    }

    private void ResumePhysics()
    {
        TimerController.GetComponent<TimerController>().ResumeTimer();
        Time.timeScale = 1;
        player.canPlay = true;
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
        SceneManager.LoadScene("gameScene");
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
