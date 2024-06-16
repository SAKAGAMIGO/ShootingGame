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
        //TimerScriptを取得
        _timerScript = GameObject.FindAnyObjectByType<TimerScript>();

        //ゲーム起動時にTextを非表示にする
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);

        //SCORを表示
        scoreText.text = "SCORE:" + score;
    }

    public void AddScore()
    {
        //敵を倒すと実行
        score += 100;
        scoreText.text = "SCORE" + score;
    }

    //GameOverTextを取得
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

    //GameのRetry
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
