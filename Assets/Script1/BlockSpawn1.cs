using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn1 : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���擾
    [SerializeField] GameObject blockPrefab1;
    [SerializeField] GameObject upeer;
    [SerializeField] GameObject low;
    
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
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(blockPrefab1);
        _enemy.transform.position = randomPos;
    }
}
