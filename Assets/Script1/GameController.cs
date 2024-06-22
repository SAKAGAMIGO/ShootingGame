using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;


public class GameController : MonoBehaviour
{ 
    public GameObject _gameOverText;
    public GameObject _gameClearText;
    public Text _scoreText;
    int _score = 0;

    private bool _isGameOver;
    private bool _isGameClear;

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
        _gameOverText.SetActive(false);
        _gameClearText.SetActive(false);

        //SCORを表示
        _scoreText.text = "SCORE:" + Environment.NewLine +  _score;

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
        _score += 100;
        _scoreText.text = "SCORE" + Environment.NewLine + _score;
    }

    public void finish()
    {
        //3秒後にCall関数を実行する
        Invoke("GameClear", 4f);
    }

    //GameOverTextを取得
    public void GameOver()
    {
        _gameOverText.SetActive(true);
        _isGameOver = true;
    }

    public  void GameClear()
    {
        _gameClearText.SetActive(true );
        _isGameClear = true;
        //SceneManager.LoadScene("ClearScene");
    }

    //GameのRetry
    private void Update()
    {
        if (_isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("ShootingGame");
        }
    }

    public void Score()
    {
        if (_score <= 500)
        {
            _enemySpawn1.SetActive(false);
        }
    }
}
