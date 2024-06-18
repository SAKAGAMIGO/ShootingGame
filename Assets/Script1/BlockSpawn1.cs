using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn1 : MonoBehaviour
{
    //ゲームオブジェクトを取得
    [SerializeField] GameObject blockPrefab1;
    [SerializeField] GameObject upeer;
    [SerializeField] GameObject low;

    [SerializeField] float interval;
    float timer;

    void Start()
    {
        
    }


    void Update()
    {
        //Spawnを2秒間隔で実行
        timer += Time.deltaTime;

        if (timer > interval)
        {
            Spawn();
            timer = 0;
        }
    }

    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(blockPrefab1);
        _enemy.transform.position = randomPos;
    }
}
