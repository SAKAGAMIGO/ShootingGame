using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn1 : MonoBehaviour
{

    //�Q�[���I�u�W�F�N�g���擾
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject upeer;
    [SerializeField] GameObject low;


    void Start()
    {
        //Spawn��1�b�Ԋu�Ŏ��s
        InvokeRepeating("Spawn", 0.8f, 0.8f);
    }

    void Update()
    {

    }

    //Enemy�𐶐�
    private void Spawn()
    {
        //�����_����x�����擾
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(enemyPrefab);
        _enemy.transform.position = randomPos;
    }
}
