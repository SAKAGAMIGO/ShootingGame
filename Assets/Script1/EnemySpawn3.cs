using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    //ゲームオブジェクトを取得
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

    //EnemyをUpeerとLowの間でランダムに生成
    private void Spawn()
    {
        //ランダムなx軸を取得
        Vector2 randomPos = new Vector2(Random.Range(upeer.transform.position.x, low.transform.position.x), Random.Range(upeer.transform.position.y, low.transform.position.y));
        GameObject _enemy = Instantiate(enemyPrefab);
        _enemy.transform.position = randomPos;

    }
}
