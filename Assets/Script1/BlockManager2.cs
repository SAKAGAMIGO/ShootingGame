using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager2: MonoBehaviour
{
    //Block�̈ړ����x
    [SerializeField] float _moveSpeed;

    //�����̃G�t�F�N�g
    public GameObject _explosion;

    //Block�̍ő�HP
    float _health = 300f;
    public float HP => _health;

    //GameController�擾
    GameController _gameController;

    /// <summary>
    /// �_���[�W��^����
    /// </summary>
    /// <param name="damage"></param>
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    void Start()
    {
        //GameController
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    
    void Update()
    {
        Move();
        OffScreen();
        //Block����]����
        transform.Rotate(0, 0, 1);

        //HP��0�ɂȂ�������s
        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            Instantiate(_explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
            //Score
            _gameController.AddScore();
        }
    }

    /// <summary>
    /// Block�����Ɉړ�������
    /// </summary>
    private void Move()
    {
        transform.position +=
            new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime;

    }

    /// <summary>
    /// Block����ʊO�ɏo�������
    /// </summary>
    private void OffScreen()
    {
        if (this.transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

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
