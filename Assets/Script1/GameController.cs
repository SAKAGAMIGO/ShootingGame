using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;


public class GameController : MonoBehaviour
{

    public GameObject gameOverText;
    public GameObject gameClearText;
    public Text scoreText;
    int score = 0;
    // PlayerManager hp;
    private bool isGameOver;
    private bool isGameClear;

    //EnemyのSponer
    public GameObject _enemySpawn1;
    public GameObject _enemySpawn2;
    public GameObject _enemySpawn3;
    public GameObject _blockSpawn;
    public GameObject _blockSpawnSmall;
    public GameObject _bossSpawn;


    TimerScript _timerScript;

    void Start()
    {

        //TimerScriptを取得
        _timerScript = GameObject.FindAnyObjectByType<TimerScript>();

        //ゲーム起動時にTextを非表示にする
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);

        //SCORを表示
        scoreText.text = "SCORE:" + Environment.NewLine +  score;

        //ゲーム起動時にObjectを非表示にする
        _enemySpawn1.SetActive(true);
        _enemySpawn2.SetActive(false);
        _enemySpawn3.SetActive(false);
        _blockSpawn.SetActive(false);
        _blockSpawnSmall.SetActive(false);
        _bossSpawn.SetActive(false);
    }

    public void AddScore()
    {
        //敵を倒すと実行
        score += 100;
        scoreText.text = "SCORE" + Environment.NewLine + score;
    }

    //GameOverTextを取得
    public void GameOver()
    {
        gameOverText.SetActive(true);
        isGameOver = true;
    }

    public static void GameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    //GameのRetry
    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("ShootingGame");
        }
    }

    public void Score()
    {
        if (score <= 500)
        {
            _enemySpawn1.SetActive(false);
        }
    }
}
