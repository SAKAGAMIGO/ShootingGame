using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public Text scoreText;
    int score = 0;
    // PlayerManager hp;
    private bool IsGameOver;

    void Start()
    {
        //ゲーム起動時にTextを非表示にする
        gameOverText.SetActive(false);

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
        IsGameOver = true;
    }

    //GameのRetry
    private void Update()
    {
        if (IsGameOver)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Shooting Game");
            }
        }
    }
    
}
