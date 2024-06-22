using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn1 : MonoBehaviour
{
    //ゲームオブジェクトを取得
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
        //Spawnを2秒間隔で実行
        timer += Time.deltaTime;

        if (timer > _interval)
        {
            Spawn();
            timer = 0;
        }
    }

    /// <summary>
    /// UpeerとLowerの間でランダムなPositionを取得
    /// </summary>
    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(_upeer.transform.position.x, _low.transform.position.x), Random.Range(_upeer.transform.position.y, _low.transform.position.y));
        GameObject _enemy = Instantiate(_blockPrefab1);
        _enemy.transform.position = randomPos;
    }
}
