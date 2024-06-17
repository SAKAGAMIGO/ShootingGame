using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn2 : MonoBehaviour
{
    //ゲームオブジェクトを取得
    [SerializeField] GameObject _blockPrefab2;
    [SerializeField] GameObject _upeer;
    [SerializeField] GameObject _low;

    void Start()
    {
        //Spawnを2秒間隔で実行
        InvokeRepeating("Spawn", 2f, 2f);
    }


    void Update()
    {

    }

    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(_upeer.transform.position.x, _low.transform.position.x), Random.Range(_upeer.transform.position.y, _low.transform.position.y));
        GameObject _enemy = Instantiate(_blockPrefab2);
        _enemy.transform.position = randomPos;
    }
}
