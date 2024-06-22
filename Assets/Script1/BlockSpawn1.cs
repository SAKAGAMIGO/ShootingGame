using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn1 : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���擾
    [SerializeField] GameObject _blockPrefab1;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    [SerializeField] float _interval;
    float timer;

    void Start()
    {
        
    }


    void Update()
    {
        //Spawn��2�b�Ԋu�Ŏ��s
        timer += Time.deltaTime;

        if (timer > _interval)
        {
            Spawn();
            timer = 0;
        }
    }

    /// <summary>
    /// Upeer��Lower�̊ԂŃ����_����Position���擾
    /// </summary>
    private void Spawn()
    {
        //�����_����x�����擾
        Vector2 randomPos = new Vector2(Random.Range(_upeer.transform.position.x, _low.transform.position.x), Random.Range(_upeer.transform.position.y, _low.transform.position.y));
        GameObject _enemy = Instantiate(_blockPrefab1);
        _enemy.transform.position = randomPos;
    }
}
