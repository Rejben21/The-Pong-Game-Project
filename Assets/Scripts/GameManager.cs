using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool hasStarted = false;

    public AudioSource menuSong;

    public GameObject leftWall;

    public Ball ball;
    public Paddle playerPaddle;
    public Paddle computerPaddle;

    private int _playerScore;
    private int _computerScore;

    public Text playerScore;
    public Text computerScore;

    public GameObject menu;
    public GameObject pauseMenu;

    public GameObject controlsText, controlsFor2;

    private bool isPaused = false;

    public bool isPlayer, isComputer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else if(!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PlayerScores()
    {
        _playerScore++;
        playerScore.text = _playerScore.ToString();
        ResetRound();
    }

    public void ComputerScores()
    {
        _computerScore++;
        computerScore.text = _computerScore.ToString();
        ResetRound();
    }

    private void ResetRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void OneVCom()
    {
        hasStarted = true;
        ball.AddStartingForce();

        Paddle.instance.isPlayer = false;
        Paddle.instance.isComputer = true;

        playerPaddle.isComputer = true;
        computerPaddle.isComputer = true;

        leftWall.GetComponent<ScoringZone>().isPlayer = false;

        AudioManager.instance.PlaySFX(4);
        AudioManager.instance.PlaySFX(5);
        menuSong.Stop();

        controlsText.SetActive(true);

        menu.SetActive(false);
    }

    public void OneVOne()
    {
        hasStarted = true;
        ball.AddStartingForce();

        Paddle.instance.isComputer = false;
        Paddle.instance.isPlayer = true;

        playerPaddle.isPlayer = true;
        computerPaddle.isPlayer = true;

        leftWall.GetComponent<ScoringZone>().isPlayer = true;

        AudioManager.instance.PlaySFX(4);
        AudioManager.instance.PlaySFX(5);
        menuSong.Stop();

        controlsFor2.SetActive(true);

        menu.SetActive(false);

    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game");
        Application.Quit();
    }
}
