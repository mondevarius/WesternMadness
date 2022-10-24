using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    
    
    public GameObject starNextLevel,
                      spawController,
                      gameOverCount,
                      canvasWrongColor;

    public AudioSource levelComplete,
                       playerDie;

    public int targetScore;
    
    private int totalScore;
    
    public Text playerScore;

    public static bool activeStar = false;
    
    private bool stopUpdate = false;

        
    void Update()
    {
        if (totalScore == targetScore)
        {
            NextLevel();
        }
        totalScore = RightHand.orangeScore + RightHand.redScore + LeftHand.purpleScore + LeftHand.blueScore;
        playerScore.text = totalScore.ToString();
        if(Cronometro.stopCount == true && stopUpdate == false)
        {
            gameOverCount.SetActive(true);
            playerDie.PlayOneShot(playerDie.clip);
            stopUpdate = true;
        }
        

    }


    void NextLevel()
    {
        Destroy(spawController.gameObject);
        starNextLevel.SetActive(true);
        levelComplete.PlayOneShot(levelComplete.clip);
        totalScore = 0;
        RightHand.orangeScore = 0;
        RightHand.redScore = 0;
        LeftHand.purpleScore = 0;
        LeftHand.blueScore = 0;
    }
    
    public void Restart()
    {
        totalScore = 0;
        RightHand.orangeScore = 0;
        RightHand.redScore = 0;
        LeftHand.purpleScore = 0;
        LeftHand.blueScore = 0;
        RightHand.bullets = 5;
        LeftHand.bullets = 5;
        gameOverCount.SetActive(false);
        canvasWrongColor.SetActive(false);
        stopUpdate = false;
        Cronometro.stopCount = false;
        LeftHand.wrongColorActive = false;
        RightHand.wrongColorActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
