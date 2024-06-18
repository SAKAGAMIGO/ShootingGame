using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���擾
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject upeer;
    [SerializeField] GameObject low;

    private float interval;

    private float time = 0f;
  
    void Start()
    {
        interval = 0.2f;
    }

    
    void Update()
    {
        

        time += Time.deltaTime;

        if (time > interval)
        {
            GameObject enemy = Instantiate(enemyPrefab,
                                           this.transform.position,
                                           transform.rotation);
            time = 0f;
            Spawn();
        }

    }

    //Enemy��Upeer��Low�̊ԂŃ����_���ɐ���
    private void Spawn()
    {
        //�����_����x�����擾
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(enemyPrefab);
        _enemy.transform.position = randomPos;

    }
}
