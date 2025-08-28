using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector2 obstacleWidthRange;
    [SerializeField] private float obstacleRotationSpeed;
    [SerializeField] private float obstacleMoveSpeed;

    private SpriteRenderer _obstacleSpriteRenderer;
    private BoxCollider2D _obstacleCollider2D;
    private float _obstacleWidth;
    private float _obstaclePositionY;
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
        SetInitials();
    }

    private void Update()
    {
        SetMotion();
        
        if (transform.position.x <= -25)
        {
            Destroy(gameObject);
        }
    }

    private void SetInitials()
    {
        float obstaclePositionUpperY = 0f;
        float obstaclePositionLowerY = 0f;
        
        //Some dirty math calculations
        if (_canRotate)
        {
            obstaclePositionUpperY = -0.5f * _obstacleWidth + 8;
            obstaclePositionLowerY = -(obstaclePositionUpperY - 1.5f);
        }
        else if (!_canRotate)
        {
            obstaclePositionLowerY = -6f;
            obstaclePositionUpperY = 7f;
        }
        
        //Initial starting position
        transform.position = new Vector3(transform.position.x, Random.Range(obstaclePositionLowerY,obstaclePositionUpperY), transform.position.z);
        
        _obstacleSpriteRenderer.size = new Vector2(_obstacleWidth, _obstacleSpriteRenderer.size.y);
        _obstacleCollider2D.size = new Vector2(_obstacleWidth - 1, _obstacleCollider2D.size.y);
    }

    private void SetMotion()
    {
        if (_canRotate)
        {
            transform.Rotate(Vector3.forward * (obstacleRotationSpeed * Time.deltaTime));
        }

        transform.Translate(Vector3.left * (obstacleMoveSpeed * Time.deltaTime), Space.World);
    }
}