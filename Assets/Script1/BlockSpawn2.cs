using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn2 : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���擾
    [SerializeField] GameObject _blockPrefab2;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    void Start()
    {
        //Spawn��2�b�Ԋu�Ŏ��s
        InvokeRepeating("Spawn", 2f, 2f);
    }


    void Update()
    {

    }

    private void Spawn()
    {
        //�����_����x�����擾
        Vector2 randomPos = new Vector2(Random.Range(_upeer.transform.position.x, _low.transform.position.x), Random.Range(_upeer.transform.position.y, _low.transform.position.y));
        GameObject _enemy = Instantiate(_blockPrefab2);
        _enemy.transform.position = randomPos;
    }
}
