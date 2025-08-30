using System;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public RingoSpawner ringoSpawner;
    private Dictionary<String, int> _playerScores =  new Dictionary<String, int>();
    
    public void SpawnRingo()
    {
        ringoSpawner.SetIsRingoOnField(false);
    }

    public void ScorePoint(GameObject otherGameObject)
    {
        if (!_playerScores.TryAdd(otherGameObject.name, 1))
        {
            _playerScores[otherGameObject.name] = 0;
        }
    }

    public void ReverseDirection(Hebi player)
    { 
        player.ReverseDirection();
    }
}
