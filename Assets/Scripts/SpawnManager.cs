using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject[] coinSplinePrefabs;

    private float _missileSpawnDelay;
    private float _obstacleSpawnDelay;
    private float _coinSplineSpawnDelay;

    private void Start()
    {
        _missileSpawnDelay = Random.Range(2f, 6f);
        _obstacleSpawnDelay = Random.Range(1f, 5f);
        _coinSplineSpawnDelay = Random.Range(1f, 3f);
    }
    
    private void Update()
    {
        if (!GameManager.Instance.GetIsJackCrashed())
        {
            SpawnMissile();
            SpawnObstacle();
            SpawnCoinSpline();
        }
    }

    private void SpawnMissile()
    {
        _missileSpawnDelay -= Time.deltaTime;

        if (_missileSpawnDelay <= 0)
        {
            Instantiate(missilePrefab, new Vector2(19f, Jack.Instance.GetCoordinateY()), Quaternion.identity);
            _missileSpawnDelay = Random.Range(2f, 6f);
        }
    }

    private void SpawnObstacle()
    {
        _obstacleSpawnDelay -= Time.deltaTime;

        if (_obstacleSpawnDelay <= 0)
        {
            Instantiate(obstaclePrefab, new Vector3(19f,0f,0f), Quaternion.identity);
            _obstacleSpawnDelay = Random.Range(1f, 5f);
        }
    }

    private void SpawnCoinSpline()
    {
        _coinSplineSpawnDelay -= Time.deltaTime;
        
        if (_coinSplineSpawnDelay <= 0)
        {
            Instantiate(coinSplinePrefabs[Random.Range(0,coinSplinePrefabs.Length)], new Vector3(19f, Random.Range(-6f, 7f), 0f), Quaternion.identity);
            _coinSplineSpawnDelay = Random.Range(1f, 5f);
        }
    }
}