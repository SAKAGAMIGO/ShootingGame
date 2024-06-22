using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    //Enemy�̈ړ����x
    [SerializeField] int _moveSpeed;

    //�Q�[���I�u�W�F�N�g���擾
    public GameObject _bulletPrefab;
    public GameObject _Muzzle1;
    public GameObject _Muzzle2;

    //�����̃G�t�F�N�g
    public GameObject _explosion;

    //Enemy�̍ő�HP
    float _health = 100f;
    public float HP => _health;

    //GameController�擾
    GameController _gameController;

    //�_���[�W��^����
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    //Enemy������������EnemyBullet�����������
    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Shot1();
        Shot2();
    }

    void Update()
    {
        Move();
        OffScreen();
        //HP��0�ɂȂ�������s
        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            Instantiate(_explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
            _gameController.AddScore();
        }
    }

    //Enemy�����Ɉړ�������
    private void Move()
    {
        transform.position +=
            new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime;
    }

    //Enemy����ʊO�ɏo�������
    private void OffScreen()
    {
        if (this.transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    //Bullet�𐶐�
    private void Shot1()
    {
        GameObject _bullet = Instantiate(_bulletPrefab);
        _bullet.transform.position = _Muzzle1.transform.position;
    }

    private void Shot2()
    {
        GameObject _bullet = Instantiate(_bulletPrefab);
        _bullet.transform.position = _Muzzle2.transform.position;
    }



    //Bullet��Player�ɂԂ���������s
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
            //�j��̃G�t�F�N�g
            Instantiate(_explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
        }
    }
}
