using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;

    private GameState gameState;

    private bool paused = false;

    void Start()
    {
        pausePanel.SetActive(false);

        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            pausePanel.SetActive(true);

            Time.timeScale = 0;
        }

        if (!paused)
        {
            pausePanel.SetActive(false);

            if(gameState.Won != true)
                Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
