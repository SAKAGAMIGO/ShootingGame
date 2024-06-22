using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    //GameObjectを追加
    public GameObject _centerCore;
    public GameObject _leftCore;
    public GameObject _rightCore;
    public GameObject _decoration;

    //Coreの数
    public int _count;

    //
    public GameObject _bossPrefab;

    //Bossの移動速度
    public int _speed = 5;

    Vector3 movePosition;

    GameController _gameController;

    //SpriteRendererを取得
    SpriteRenderer _sp;

    //点滅の間隔
    [SerializeField] float _flashInterval;

    //点滅させるときのループカウント
    [SerializeField] int _loopCount;

    //当たったかどうかのフラグ
    bool _isHit;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        movePosition = moveRandomPosition();

        //SpriteRenderer,BoxCollider2D,CapsuleCollider2Dを格納
        _sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (movePosition == _bossPrefab.transform.position)
        {
            movePosition = moveRandomPosition();
        }
        this._bossPrefab.transform.position = Vector3.MoveTowards(_bossPrefab.transform.position, movePosition, _speed * Time.deltaTime);

        if (_count == 0)
        {
            //AudioSource audio = this.gameObject.GetComponent<AudioSource>();
            //audio.Play();
            _decoration.SetActive(false);
             _sp.enabled = false;
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
        //Hitしていたら処理を行わない
        if (_isHit)
        {
            return;
        }
        //コルーチンを開始
        StartCoroutine(_hit());
    }

    //点滅させる処理
    IEnumerator _hit()
    {
        //当たりフラグをtrueに変更（当たっている状態）
        _isHit = true;

        //点滅ループ開始
        for (int i = 0; i < _loopCount; i++)
        {
            //flashInterval待ってから
            yield return new WaitForSeconds(_flashInterval);
            //spriteRendererをオフ
            _sp.enabled = false;

            //flashInterval待ってから
            yield return new WaitForSeconds(_flashInterval);
            //spriteRendererをオン
            _sp.enabled = true;
        }

        //点滅ループが抜けたら当たりフラグをfalse(当たってない状態)
        _isHit = false;
    }
}
