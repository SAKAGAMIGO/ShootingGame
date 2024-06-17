using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bossPrefab;
    
    void Start()
    {
        Instantiate(_bossPrefab,_bossPrefab.transform.position,_bossPrefab.transform.rotation);
    }

    void Update()
    {
        
    }
}
