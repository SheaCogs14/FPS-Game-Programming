using UnityEngine;
using TMPro;
using System;



public class PlayerCollect : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI itemUi, gameTimeUi;

    private float _timer = 0.0f;
    private int _seconds;

    private int _currentScore = 0;

    private void Update()
    {
        ScoreUpdate();
        UpdateTimer();
    }
    public void UpdateScore()
    {
        _currentScore++;
    }

    public void ScoreUpdate()
    {
        itemUi.text = _currentScore.ToString();
    }

    public void UpdateTimer()
    {
        _timer -= Time.deltaTime;
        _seconds = Convert.ToInt32(_timer % 60);
        gameTimeUi.text = _seconds.ToString();
    }
}
