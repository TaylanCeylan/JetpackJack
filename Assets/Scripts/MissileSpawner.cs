using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float missileSpawnPosX;

    private float _missileDelay = 3f;

    private void Update()
    {
        _missileDelay -= Time.deltaTime;

        if (_missileDelay <= 0f)
        {
            Instantiate(missilePrefab, new Vector2(missileSpawnPosX, Jack.Instance.GetCoordinateY()), Quaternion.identity);
            _missileDelay = 3f;
        }
    }
}
