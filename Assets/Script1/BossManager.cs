using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    int count;

    //ƒ{ƒX‚ÌŒ‚”j‰¹
    [SerializeField] AudioClip _bossDestroyAudio;

    public GameObject _centerCore;
    public GameObject _leftCore;
    public GameObject _rightCore;

    [SerializeField] int _count;

    public GameObject player;

    public int speed = 5;
    bool ok = false;
    Vector3 movePosition;

    void Start()
    {
        movePosition = moveRandomPosition();
    }

    void Update()
    {
        if (movePosition == player.transform.position)
        {
            movePosition = moveRandomPosition();
        }
        this.player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);

        if (_count == 0)
        {
            AudioSource.PlayClipAtPoint(_bossDestroyAudio, transform.position);
            Destroy(gameObject);
            GameController.GameClear();
        }
    }

    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }

    public void Count()
    {
        _count--;
    }
}
