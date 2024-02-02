using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private GameObject gameLosePanel;
    [SerializeField] private GameObject gamePausePanel;
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject nextLevel;

    [SerializeField] private gameManager gameManager;
    [SerializeField] private TextMeshProUGUI tapCountText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI levelNumText;
    [SerializeField] private TextMeshProUGUI TargetText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI ResetHighscoreText;
    [SerializeField] private TextMeshProUGUI CountDownText;
 
    public bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
   public void Update()
    {
        TimerText.text = "Timer:" + gameManager.timer.ToString("N0");
        if (!gameManager.CountDownTimerEnded)
        {
            CountDownText.text = gameManager.countDown.ToString("N0");
        }
        TargetText.text = "Target:" + gameManager.targetCount.ToString();
        levelNumText.text = "Level:" + gameManager.getLevelNum().ToString();
       
    }

    public void DisableCountDownTimer()
    {
        CountDownText.gameObject.SetActive(false);
    }

    public void BackBtnCLicked()
    {
        SceneManager.LoadScene(0);
    }
    public void MainMenuBtnCLicked()
    {
       
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
       
    }
    public void RestartBtnCLicked()
    {
       
        SceneManager.LoadScene(1);
    }
    public void UpdatingTapCount()
    {
        tapCountText.text = gameManager.tapCount.ToString();
    }

    public void HighScoreUI()
    {
        highScoreText.text ="highScore :" + gameManager.highScore.ToString();
    }  

    public void WinLoseScreen()
    {
        if (gameManager.hasWon)
        {
            pauseBtn.SetActive(false);
            gameWinPanel.SetActive(true);
        }
        else
        {
            pauseBtn.SetActive(false);
            gameLosePanel.SetActive(true);
        }
    }

    public void ResetHighScoreBtnClicked()
    {
        gameManager.ResetHighScore();
        gameManager.HighscoreUpdate();
        Debug.Log("Reset Clicked");
    }

    public void PauseBtnClicked()
    {
       
        gamePausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeBtnClicked()
    {
       
        isPaused = false;
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void NextBtn()
    {
        
        gameManager.IncreaseLevel();
        Debug.Log("Current Level"+gameManager.getLevelNum());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
