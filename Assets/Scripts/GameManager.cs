using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get ; private set;}
    
    private float _score;
    private int _coinScore;
    private bool _isJackCrashed = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _score = 0;
        _coinScore = 0;
        
        Jack.Instance.OnCoinPickUp += InstanceOnOnCoinPickUp;
        Jack.Instance.OnCrash += InstanceOnOnCrash;
    }

    private void InstanceOnOnCrash()
    {
        _isJackCrashed = true;
    }

    private void InstanceOnOnCoinPickUp()
    {
        _coinScore += 50;
    }

    private void Update()
    {
        if (!_isJackCrashed)
        {
            _score += Time.deltaTime * 20f;
        }
    }

    public float GetScore()
    {
        return Mathf.Floor(_score);
    }

    public int GetCoinScore()
    {
        return _coinScore;
    }

    public bool GetIsJackCrashed()
    {
        return _isJackCrashed;
    }
}
