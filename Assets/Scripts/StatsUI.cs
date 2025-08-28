using System;
using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    private TextMeshProUGUI statsText;

    private void Awake()
    {
        statsText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        statsText.text = GameManager.Instance.GetScore().ToString() + "\n" + GameManager.Instance.GetCoinScore().ToString();
    }
}
