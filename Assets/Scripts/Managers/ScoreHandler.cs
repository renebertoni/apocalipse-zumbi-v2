using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour
{
    int _deadEnemies = 0;
    int _recordDeadEnemies;

    int _rescuedSurvivors = 0;
    int _recordRescuedSurvivors = 0;

    float _recordTimeSurvived = 10;
    Helper _helper;

    public static Action<Score, bool> ShowScore;

    void Start()
    {
        _helper = new Helper();
    }

    void OnEnable()
    {
        EnemyHealth.EnemyDead += DeadEnemies;
        GameHandler.GameOver += ScoreCount;
    }

    void OnDisable()
    {
        EnemyHealth.EnemyDead -= DeadEnemies;
        GameHandler.GameOver -= ScoreCount;
    }

    void ScoreCount()
    {
        bool newRecord = false;
        Score currentScore = new Score(Time.timeSinceLevelLoad, _deadEnemies, _rescuedSurvivors);
        Score recordScore = new Score(_recordTimeSurvived, _recordDeadEnemies, _recordRescuedSurvivors);

        if(currentScore.ScorePoints > recordScore.ScorePoints)
        {
            newRecord = true;
            recordScore = currentScore;
            _helper.Save(currentScore);
        }
        ShowScore?.Invoke(currentScore, newRecord);
    }

    void DeadEnemies()
    {
        _deadEnemies++;
    }

    void RescuedSurvivors()
    {
        _rescuedSurvivors++;
    }
}
