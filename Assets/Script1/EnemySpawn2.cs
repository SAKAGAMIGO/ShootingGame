using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{

    //�Q�[���I�u�W�F�N�g���擾
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    [SerializeField] float _interval;
    float timer;

    void Start()
    {
        //Spawn��1�b�Ԋu�Ŏ��s
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > _interval)
        {
            Spawn();
            timer = 0;
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
