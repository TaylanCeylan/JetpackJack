using System;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float missileSpeed;
    
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x <= -25)
        {
            DestroySelf();
        }
    }

    private void FixedUpdate()
    {
        SetMotion();
    }

    private void SetMotion()
    {
        _rigidbody2D.AddForce(Vector2.left * (missileSpeed * Time.deltaTime), ForceMode2D.Impulse);
        _rigidbody2D.linearVelocityX = Mathf.Clamp(_rigidbody2D.linearVelocityX, -20f, 0f);
    }
    
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
