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
    public GameObject _explotion;

    //Coreの数
    public int _count;

    //
    public GameObject _bossPrefab;

    //Bossの移動速度
    public int _speed = 5;

    //Bossの移動範囲
    Vector3 movePosition;

    //SpriteRendererを取得
    SpriteRenderer _sp;

    //点滅の間隔
    [SerializeField] float _flashInterval;

    //点滅させるときのループカウント
    [SerializeField] int _loopCount;

    //当たったかどうかのフラグ
    bool _isHit;


    //component
    GameController _gameController;


    void Start()
    {
        //GameControllerを格納
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //SpriteRendererを格納
        _sp = GetComponent<SpriteRenderer>();
        //動ける範囲を指定
        movePosition = moveRandomPosition();
    }

    void Update()
    {
        Move();

        if (_count == 0)
        {

            //爆発のエフェクト
            Instantiate(_explotion, transform.position, transform.rotation);
            _decoration.SetActive(false);
            _sp.enabled = false;
            ////ClerScoreを表示
            _gameController.finish();
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (movePosition == _bossPrefab.transform.position)
        {
            movePosition = moveRandomPosition();
        }
        this._bossPrefab.transform.position = Vector3.MoveTowards(_bossPrefab.transform.position, movePosition, _speed * Time.deltaTime);
    }

    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), 4);
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
