using System;
using UnityEngine;
using UnityEngine.Splines;
using Object = UnityEngine.Object;

public class CoinSpline : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    
    private SplineContainer _splineContainer;
    private BezierKnot[] _knots;

    private void Awake()
    {
        _splineContainer = GetComponent<SplineContainer>();
    }

    private void Start()
    {
        _knots = _splineContainer.Spline.ToArray();
        
        for (int i = 0; i < _knots.Length; i++)
        {
            Instantiate(coinPrefab, new Vector2(_knots[i].Position.x + transform.position.x, _knots[i].Position.y + transform.position.y), Quaternion.identity);
        }
    }
}
