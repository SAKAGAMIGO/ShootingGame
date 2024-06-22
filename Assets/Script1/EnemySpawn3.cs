using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���擾
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    float _interval = 10f;

    float _timer = 1;

    void Start()
    {
        _interval = 0.2f;
    }
    
    void Update()
    {
        //Spawn��1�b�Ԋu�Ŏ��s
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            Spawn();
            _timer = 0f;
        }

    }

    //Enemy��Upeer��Low�̊ԂŃ����_���ɐ���
    private void Spawn()
    {
        //�����_����x�����擾
        Vector2 randomPos = new Vector2(Random.Range(_upeer.transform.position.x, _low.transform.position.x), Random.Range(_upeer.transform.position.y, _low.transform.position.y));
        GameObject _enemy = Instantiate(_enemyPrefab);
        _enemy.transform.position = randomPos;

    }
}
