using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenterCore : MonoBehaviour
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

    //BossManager
    BossManager _manager;

    //Bullet
    public int _intrval = 0;

    //�_���[�W��^����
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    

    /// <summary>
    /// Enemy������������EnemyBullet�����������
    /// </summary>
    public void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _manager = GetComponentInParent<BossManager>();
        if (!_manager) Debug.Log("manager not found.");

    }

    void Update()
    {
        _intrval++;
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

    /// <summary>
    /// Bullet�𐶐�
    /// </summary>
    private void Shot()
    {
        if (_intrval % 300 == 0)
        {
            GameObject _bullet = Instantiate(_bulletPrefab);
            _bullet.transform.position = _Muzzle.transform.position;
        }
    }

    ///Player�ɓ�����������s
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�Ƀ_���[�W��^����
            collision.gameObject.GetComponent<PlayerManager>().AddDamage(10f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 100f;
            Instantiate(_explosion, transform.position, transform.rotation);
        }
    }

    /// <summary>
    /// Destroy���Ɏ��s
    /// </summary>
    public void OnDestroy()
    {
        _gameController.AddScore();
        _manager.Count();
    }
}
