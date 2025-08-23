using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    private float _obstacleSpawnDelay = 3f;
    
    private void Update()
    {
        _obstacleSpawnDelay  -= Time.deltaTime;

        if (_obstacleSpawnDelay <= 0)
        {
            Instantiate(obstaclePrefab, new Vector3(19f,0f,0f), Quaternion.identity);
            _obstacleSpawnDelay = 3f;
        }
    }
}
