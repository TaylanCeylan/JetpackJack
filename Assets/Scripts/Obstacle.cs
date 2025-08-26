using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector2 obstacleWidthRange;
    [SerializeField] private float obstacleRotationSpeed;

    private SpriteRenderer _obstacleSpriteRenderer;
    private BoxCollider2D _obstacleCollider2D;
    private float _obstacleWidth;
    private bool _canRotate;

    private void Awake()
    {
        _obstacleWidth = Random.Range(obstacleWidthRange.x, obstacleWidthRange.y);
        _canRotate = Random.value > 0.5f;
        
        _obstacleCollider2D = GetComponent<BoxCollider2D>();
        _obstacleSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _obstacleSpriteRenderer.size = new Vector2(_obstacleWidth, _obstacleSpriteRenderer.size.y);
        _obstacleCollider2D.size = new Vector2(_obstacleWidth - 1, _obstacleCollider2D.size.y);
    }

    private void Update()
    {
        if (_canRotate)
        {
            transform.Rotate(Vector3.forward * (obstacleRotationSpeed * Time.deltaTime));
        }
    }
}