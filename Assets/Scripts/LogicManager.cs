using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LogicManager : MonoBehaviour
{
    public RingoSpawner ringoSpawner;
    public TextMeshProUGUI scoreText;
    private readonly Dictionary<String, int> _playerScores =  new Dictionary<String, int>();

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void SpawnRingo()
    {
        ringoSpawner.SetIsRingoOnField(false);
    }

    public void ScorePoint(GameObject otherGameObject)
    {
        if (_playerScores.TryAdd(otherGameObject.name, 1))
        {
            scoreText.text = _playerScores[otherGameObject.name].ToString();
            return;
        }

        _playerScores[otherGameObject.name] += 1;
        scoreText.text = _playerScores[otherGameObject.name].ToString();
    }

    public void ReverseDirection(Hebi player)
    { 
        player.ReverseDirection();
    }
}
