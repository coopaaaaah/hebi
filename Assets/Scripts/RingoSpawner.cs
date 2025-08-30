using System;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;

public class RingoSpawner : MonoBehaviour
{
    private readonly int _gridSizeX = 4;
    private readonly int _gridSizeY = 3;
    private bool _isRingoOnField;
    
    public GameObject ringo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRingo(0, 0);
        _isRingoOnField = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRingoOnField)
        {
            return;
        }
        
        SpawnRingo(Random.Range(-_gridSizeX, _gridSizeX), Random.Range(-_gridSizeY, _gridSizeY));
        _isRingoOnField = true;
    }

    public void SetIsRingoOnField(bool isOnField)
    {
        _isRingoOnField = isOnField;
    }

    private void SpawnRingo(int x, int y)
    {
        // Calculate world position based on grid coordinates and cell size
        Vector2 spawnPosition = new Vector2(x, y);
        Instantiate(ringo, spawnPosition, Quaternion.identity);
    }

}
