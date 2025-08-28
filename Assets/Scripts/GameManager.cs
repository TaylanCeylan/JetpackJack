using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        if (_isJackCrashed)
        {
            StartCoroutine(CrashRestartDelay());
        }
    }

    IEnumerator CrashRestartDelay()
    {
        yield return new WaitForSeconds(2f);
        _isJackCrashed = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
