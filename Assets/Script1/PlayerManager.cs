using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //プレイヤーの移動速度
    [SerializeField] int moveSpeed = 5;

    float _interval = 0;

    //Bullet生成のインたーバル
    [SerializeField] float _intervalMax = 1;

    //playerの移動範囲
    [SerializeField] Transform _leftPosition;
    [SerializeField] Transform _rightPosition;
    [SerializeField] Transform _upperPosition;
    [SerializeField] Transform _lowerPosition;

    //GameControllerを取得
    public GameController _gameController;

    //Playerの最大HP
    float _health = 100f;
    public float HP => _health;

    //ゲームオブジェクトを取得
    public GameObject bulletPrefab;
    public GameObject Muzzle1;
    public GameObject Muzzle2;

    public GameObject explosion;

    //
    HealthGuage _healthGuage;

    public void AddDamage(float damage)
    {
        _health -= damage;
        _healthGuage.TakeDamage(damage * .01f);
    }

    private void Start()
    {
        //HealthGuageを取得
        _healthGuage = GameObject.FindAnyObjectByType<HealthGuage>();
    }

    // 左クリックを押すとBulletが生成される
    void Update()
    {
        //Move();
        _interval += Time.deltaTime;
        //Move();
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
            //破壊のエフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            _gameController.GameOver();
            Destroy(this.gameObject);
        }
    }



    //プレイヤーを移動させる関数
    private void Move()
    {
        //キーの入力値を取得
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;
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

}
