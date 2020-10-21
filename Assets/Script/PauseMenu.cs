using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject pauseMenu;
    private LvlLoader lvlLoader;
    private bool paused = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        pauseMenu.SetActive(false);
        lvlLoader = FindObjectOfType<LvlLoader>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                player.state = PlayerMovement.State.UI;
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
        TimeGo();
        SoundManager.instance.StopAll();
        lvlLoader.LoadSomeLvl(0);
    }
    public void Continue()
    {
        TimeGo();
    }

    void TimeGo()
    {
        Time.timeScale = 1;
        paused = false;
        player.state = PlayerMovement.State.normal;
        pauseMenu.SetActive(false);
    }
}
