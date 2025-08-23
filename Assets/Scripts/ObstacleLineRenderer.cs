using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleLineRenderer : MonoBehaviour
{
    [SerializeField] private GameObject[]  obstacles;
    [SerializeField] private LineRenderer obstacleLineRenderer;

    private void Start()
    {
        obstacleLineRenderer.positionCount = obstacles.Length;

        obstacles[0].transform.localPosition = new Vector3(0f, Random.Range(-2f, 7f), 0f);
        obstacles[1].transform.localPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(-5f, obstacles[0].transform.position.y - 1), 0f);
    }

    private void Update()
    {
        obstacles[0].transform.position += new Vector3(-15f * Time.deltaTime, 0, 0);
        obstacles[1].transform.position += new Vector3(-15f * Time.deltaTime, 0, 0);
        
        obstacleLineRenderer.SetPosition(0, obstacles[0].transform.position - transform.position);
        obstacleLineRenderer.SetPosition(1, obstacles[1].transform.position - transform.position);
    }
}