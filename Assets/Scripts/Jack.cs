using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jack : MonoBehaviour
{
    public static Jack Instance {get; private set;}

    public event Action OnCrash;
    
    [SerializeField] private float jetpackForce;
    [SerializeField] private float minVelocityRangeY;
    [SerializeField] private float maxVelocityRangeY;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        JetpackThrust();
    }

    private void JetpackThrust()
    {
        if (InputManager.Instance.IsJetThrustPressed())
        {
            _rigidbody2D.AddForce(Vector2.up * (jetpackForce * Time.deltaTime), ForceMode2D.Impulse);
        }

        //Keeps the y velocity between the desired float value.
        _rigidbody2D.linearVelocityY = Mathf.Clamp(_rigidbody2D.linearVelocityY, minVelocityRangeY, maxVelocityRangeY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Missile missile))
        {
            missile.DestroySelf();
            OnCrash?.Invoke();
        }

        if (other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            OnCrash?.Invoke();
        }
    }

    public float GetCoordinateY()
    {
        return transform.position.y;
    }
}
