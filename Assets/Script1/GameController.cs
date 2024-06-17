using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject gameClearText;
    public Text scoreText;
    int score = 0;
    // PlayerManager hp;
    private bool isGameOver;
    private bool isGameClear;



    TimerScript _timerScript;

    void Start()
    {
        //TimerScript���擾
        _timerScript = GameObject.FindAnyObjectByType<TimerScript>();

        //�Q�[���N������Text���\���ɂ���
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);

        //SCOR��\��
        scoreText.text = "SCORE:" + score;
    }

    public void AddScore()
    {
        //�G��|���Ǝ��s
        score += 100;
        scoreText.text = "SCORE" + score;
    }

    //GameOverText���擾
    public void GameOver() 
    {
        gameOverText.SetActive(true);
        isGameOver = true;
    }

    public void GameClear()
    {
        gameClearText.SetActive(true);
        isGameClear = true;
    }

    //Game��Retry
    private void Update()
    {
        if (isGameOver)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Shooting Game");
            }
        }
    }
}
