using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRightCore : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���擾
    public GameObject _bulletPrefab;
    public GameObject _Muzzle;

    //�����̃G�t�F�N�g
    public GameObject _explosion;

    //Enemy�̍ő�HP
    float _health = 2000f;
    public float HP => _health;

    //GameController�擾
    GameController _gameController;

    private int count = 0;
    //�_���[�W��^����
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    BossManager _manager;


    //Enemy������������EnemyBullet�����������
    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _manager = GetComponentInParent<BossManager>();
    }

    void Update()
    {
        count++;

        Shot();
        //HP��0�ɂȂ�������s
        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            Instantiate(_explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
        }
    }

    //Bullet�𐶐�
    private void Shot()
    {
        if (count % 400 == 0)
        {
            GameObject _bullet = Instantiate(_bulletPrefab);
            _bullet.transform.position = _Muzzle.transform.position;
        }
    }

        //Player�ɓ�����������s
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
            //�j��̃G�t�F�N�g
            Instantiate(_explosion, transform.position, transform.rotation);
        }
    }

    public void OnDestroy()
    {
        _gameController.AddScore();
        _manager.Count();
    }
}
