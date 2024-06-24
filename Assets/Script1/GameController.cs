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
    public GameObject _gamePanelText;
    public Text _scoreText;
    public Text _clearScoreText;
    int _score = 0;
    public GameObject _canvas;

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
        _gamePanelText.SetActive(false);

        //
        _canvas.SetActive(false);

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
        _scoreText.text = "SCORE:" + Environment.NewLine + _score;
    }

    public void finish()
    {
        //ClerScoreを表示
        _clearScoreText.text = Environment.NewLine + Environment.NewLine + Environment.NewLine +  Environment.NewLine + "YOUR SCORE:" + _score;
        //3秒後にCall関数を実行する
        Invoke("GameClear", 3f);
    }

    //GameOverTextを取得
    public void GameOver()
    {
        _gameOverText.SetActive(true);
        _isGameOver = true;
    }

    //GameClearTextを取得
    public  void GameClear()
    {
        _gameClearText.SetActive(true);
        _canvas.SetActive(true);
        _isGameClear = true;
        _gamePanelText.SetActive(true);
        //SceneManager.LoadScene("ClearScene");
    }

    //GameのRetry
    private void Update()
    {
        if (_isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("ShootingGame");
        }

        if (_isGameClear && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScene");
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
