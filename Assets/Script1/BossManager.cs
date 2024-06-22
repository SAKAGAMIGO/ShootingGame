using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{

    //É{ÉXÇÃåÇîjâπ
    [SerializeField] AudioClip _bossDestroyAudio;

    //GameObjectÇí«â¡
    public GameObject _centerCore;
    public GameObject _leftCore;
    public GameObject _rightCore;
    
    //CoreÇÃêî
    [SerializeField] int _count;

    //
    public GameObject _player;

    //
    public int _speed = 5;

    //
    bool ok = false;

    Vector3 movePosition;

    GameController _gameController;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        movePosition = moveRandomPosition();
    }

    void Update()
    {
        if (movePosition == _player.transform.position)
        {
            movePosition = moveRandomPosition();
        }
        this._player.transform.position = Vector3.MoveTowards(_player.transform.position, movePosition, _speed * Time.deltaTime);

        if (_count == 0)
        {
            AudioSource.PlayClipAtPoint(_bossDestroyAudio, transform.position);
            _gameController.finish();

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
