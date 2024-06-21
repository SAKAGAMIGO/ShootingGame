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

    //Enemy��Sponer
    public GameObject _enemySpawn1;
    public GameObject _enemySpawn2;
    public GameObject _enemySpawn3;
    public GameObject _blockSpawn;
    public GameObject _blockSpawnSmall;
    public GameObject _bossSpawn;


    TimerScript _timerScript;

    void Start()
    {

        //TimerScript���擾
        _timerScript = GameObject.FindAnyObjectByType<TimerScript>();

        //�Q�[���N������Text���\���ɂ���
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);

        //SCOR��\��
        scoreText.text = "SCORE:" + Environment.NewLine +  score;

        //�Q�[���N������Object���\���ɂ���
        _enemySpawn1.SetActive(true);
        _enemySpawn2.SetActive(false);
        _enemySpawn3.SetActive(false);
        _blockSpawn.SetActive(false);
        _blockSpawnSmall.SetActive(false);
        _bossSpawn.SetActive(false);
    }

    public void AddScore()
    {
        //�G��|���Ǝ��s
        score += 100;
        scoreText.text = "SCORE" + Environment.NewLine + score;
    }

    //GameOverText���擾
    public void GameOver()
    {
        gameOverText.SetActive(true);
        isGameOver = true;
    }

    public static void GameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    //Game��Retry
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
