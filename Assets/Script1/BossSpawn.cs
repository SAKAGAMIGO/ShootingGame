using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bossPrefab;
    [SerializeField] GameObject _bossSpawnPos;

    [SerializeField] float interval;
    float timer;

    void Start()
    {
      
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            Spawn();
            timer = 0;
        }
    }

    private void Spawn()
    {
        GameObject _enemy = Instantiate(_bossPrefab);
        _enemy.transform.position = _bossSpawnPos.transform.position;
    }
}
