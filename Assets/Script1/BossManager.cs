using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
   // private Vector3 move = Vector3(5,0,0);
    //Enemy�̍ő�HP
    float _health = 20000f;
    public float HP => _health;

    GameController _gameController;

    //�_���[�W��^����
    public void AddDamage(float damage)
    {
        _health -= damage;
    }

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        
    }

    void Update()
    {
        //HP��0�ɂȂ�������s
        if (_health <= 0)
        {
            //�j��̃G�t�F�N�g
            //Instantiate(explosion, transform.position, transform.rotation);
            //�j�󂳂��
            Destroy(this.gameObject);
            //ClearScene�ɒ���
            SceneManager.LoadScene("ClearScene");
        }
    }

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
        }
    }
}