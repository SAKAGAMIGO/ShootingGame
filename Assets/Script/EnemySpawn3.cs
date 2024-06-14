using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    //ゲームオブジェクトを取得
    [SerializeField] GameObject enemyPrefab;

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
        }

    }
}
