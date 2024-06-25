using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;


public class PlayerManager : MonoBehaviour
{
    //プレイヤーの移動速度
    [SerializeField] int _moveSpeed = 5;

    //Bullet生成のインターバル
    float _interval = 0;

    //Bullet    の生成インターバルの最大値
    [SerializeField] float _intervalMax = 1;

    //playerの移動範囲
    [SerializeField] Transform _leftPosition;
    [SerializeField] Transform _rightPosition;
    [SerializeField] Transform _upperPosition;
    [SerializeField] Transform _lowerPosition;

    //GameControllerを取得
    [SerializeField] GameController _gameController;

    //Playerの最大HP
    float _health = 100f;
    public float HP => _health;

    //ゲームオブジェクトを取得
    public GameObject bulletPrefab;
    public GameObject Muzzle1;
    public GameObject Muzzle2;

    //爆発エフェクト
    public GameObject explosion;

    //Playerの体力
    HealthGuage _healthGuage;
    AudioSource _audioSource;

    //SpriteRendererを取得
    SpriteRenderer _sp;

    //点滅の間隔
    [SerializeField] float _flashInterval;

    //点滅させるときのループカウント
    [SerializeField] int _loopCount;

    //当たったかどうかのフラグ
    bool _isHit;

    //コライダーをオンオフするためのCollider2D
    BoxCollider2D _bCollider;
    CapsuleCollider2D _cCollider;

    public void AddDamage(float damage)
    {
        _health -= damage;
        _healthGuage.TakeDamage(damage);
        var impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();

    }

    private void Start()
    {
        //HealthGuageを取得
        _healthGuage = GameObject.FindAnyObjectByType<HealthGuage>();
        _audioSource = GameObject.Find("GameController").GetComponent<AudioSource>();
        //Setup時に最大HPを取得
        _healthGuage.Setup(_health);

        //SpriteRenderer,BoxCollider2D,CapsuleCollider2Dを格納
        _sp = GetComponent<SpriteRenderer>();
        _bCollider = GameObject.FindAnyObjectByType<BoxCollider2D>();
        _cCollider = GameObject.FindAnyObjectByType<CapsuleCollider2D>();
    }

    // 左クリックを押すとBulletが生成される
    void Update()
    {
        _interval += Time.deltaTime;
        if (_interval >= _intervalMax && Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, //生成したいオブジェクト
                        Muzzle1.transform.position, //位置
                        transform.rotation); //回転
            _interval = 0;

            Instantiate(bulletPrefab, //生成したいオブジェクト
                        Muzzle2.transform.position, //位置
                        transform.rotation); //回転
            _interval = 0;

        }
        Move();
        if (_health <= 0)
        {
            //BGMを止める
            _audioSource.Stop();
            //破壊のエフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            //GameOverを判定
            _gameController.GameOver();
            //Colliderをオフにする
            _bCollider.enabled = false;
            _cCollider.enabled = false;
            //PlayerをDestroy させる
            Destroy(gameObject);
        }
    }

    //プレイヤーを移動させる関数
    private void Move()
    {
        //キーの入力値を取得
        float x = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * _moveSpeed;
        if (transform.position.x < _leftPosition.position.x && x < 0)
        {
            x = 0;
        }
        if (transform.position.x > _rightPosition.position.x && x > 0)
        {
            x = 0;
        }
        if (transform.position.y > _upperPosition.position.y && y > 0)
        {
            y = 0;
        }
        if (transform.position.y < _lowerPosition.position.y && y < 0)
        {
            y = 0;
        }
        //取得した入力値を反映させる
        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
    }

    //当たったときの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

        _bCollider.enabled = false;
        _cCollider.enabled = false;

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
        _bCollider.enabled = true;
        _cCollider.enabled = true;
    }
}
