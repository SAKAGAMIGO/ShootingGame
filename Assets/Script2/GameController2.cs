using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    [SerializeField] GameObject titleCanvas;

    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
     void Stage1()
    {
        SceneChange("ShootingGame");
    }
    public void GetStage1()
    {
        Invoke(nameof(Stage1),1);
    }

     void Explanation()
    {
        SceneManager.LoadScene("OperationScene");
    }

    public void GetExplanation()
    {
        Invoke(nameof(Explanation), 1);
    }

    public void Title()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Audio() 
    {
        _audioSource.Play();
    }
    void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
