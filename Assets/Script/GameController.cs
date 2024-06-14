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
        //�Q�[���N������Text���\���ɂ���
        gameOverText.SetActive(false);

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
        IsGameOver = true;
    }

    //Game��Retry
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
