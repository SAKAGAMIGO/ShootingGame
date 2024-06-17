using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    [SerializeField] GameObject titleCanvas;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && titleCanvas.active)
        {
            StageSelectUiActive();
            Debug.Log("aa");
        }
    }

    public void StageSelectUiActive()
    {
        titleCanvas.SetActive(false);
    }
    public void Stage1()
    {
        SceneManager.LoadScene("ShootingGame");
    }

    public void Explanation()
    {
        SceneManager.LoadScene("ExplanationScene");
    }

    public void Title()
    {
        SceneManager.LoadScene("StartScene");
    }
}
