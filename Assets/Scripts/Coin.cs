using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float coinMoveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.left * (coinMoveSpeed * Time.deltaTime), Space.World);

        if (transform.position.x < -20)
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
