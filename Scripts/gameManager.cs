using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    [SerializeField] public int tapCount;
    [SerializeField] private float defaultTime;
    public float timer;
    private bool hasTimerEnded;
    public bool hasWon;
    public int targetCount;
    public static int highScore;
    public float countDown;
    public bool CountDownTimerEnded;
    [SerializeField] private AudioSource aD;
    [SerializeField] private AudioClip[] audioClipsArray;
    private int LevelNum=1;
    private int LevelMultiplier=10;
    [SerializeField] private ParticleSystem ParticleEffect=null;
    // Start is called before the first frame update
    void Start()
    {

        countDown = 3;
        CountDownTimerEnded = false;
        LoadHighScore();
        timer = defaultTime;
        LevelNum = PlayerPrefs.GetInt("LevelNum", 1);
        targetCount = TapTargetCount(LevelNum);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!CountDownTimerEnded)
        {
            countDown -= Time.deltaTime;
           
            if (countDown <= 0)
            {
                CountDownTimerEnded = true;
                gameUI.DisableCountDownTimer();
            }
        }
        if (CountDownTimerEnded && !hasTimerEnded)
        {
            timer -= Time.deltaTime;
            gameUI.Update();

            if (timer<=0)
            {
                hasTimerEnded = true;
                timer = 0;
                

                if (tapCount >= targetCount)
                {
                    // you won
                    hasWon = true;
                }
                else
                {
                    // you lose
                    hasWon = false;
                }
                // game over
              
                HighscoreUpdate();
            
                gameUI.WinLoseScreen();

            }

            if (!gameUI.isPaused &&  Input.GetMouseButtonDown(0))
            {
                ParticleEffect.Play();
                TapSound();
                tapCount++;
                gameUI.UpdatingTapCount();
            }
            ResetLevel();
        }

    }
    public void HighscoreUpdate()
    {
        if(highScore<tapCount)
        highScore = tapCount;
        SaveHighScore();
        gameUI.HighScoreUI();
    }

    public void SaveHighScore() // for saving highscore
    {
       PlayerPrefs.SetInt("HighScore",highScore);
    }

    public void LoadHighScore()
    {
      highScore= PlayerPrefs.GetInt("HighScore",0);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
    } 
    public void ResetLevel()
    {
        if (!hasWon)
        {
            PlayerPrefs.DeleteKey("LevelNum");
          
        }
    }

   private void TapSound()
    {
        int randomSoundsofTap = Random.Range(0, audioClipsArray.Length);
        AudioClip audios = audioClipsArray[randomSoundsofTap];
        aD.PlayOneShot(audios);
    }

    int TapTargetCount(int levelNum  )
    {
        int temp = 0;
        temp = LevelMultiplier * levelNum;
        return temp;
    }
    public void IncreaseLevel()
    {
        LevelNum++;
        PlayerPrefs.SetInt("LevelNum", LevelNum);
    }

    public int  getLevelNum()
    {
        return LevelNum;
    }
}
