using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject pauseMenu;
    private bool paused = false;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                player.state = PlayerController.State.UI;
                pauseMenu.SetActive(true);
            }
            else
            {
                TimeGo();
            }
        }
    }
    public void ExitToMenu()
    {
        
        //SceneManager.LoadScene("Menu");
    }
    public void Continue()
    {
        TimeGo();
    }

    void TimeGo()
    {
        Time.timeScale = 1;
        paused = false;
        player.state = PlayerController.State.Normal;
        pauseMenu.SetActive(false);
    }
}
