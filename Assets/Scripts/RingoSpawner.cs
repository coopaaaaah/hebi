using System.Net;
using UnityEngine;

public class RingoSpawner : MonoBehaviour
{
    private readonly int _gridSizeX = 2;
    private readonly int _gridSizeY = 6;
    private bool _isRingoOnField;
    
    public GameObject ringo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRingo();
        _isRingoOnField = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRingoOnField)
        {
            return;
        }
        
        SpawnRingo();
        _isRingoOnField = true;
    }

    public void SetIsRingoOnField(bool isOnField)
    {
        _isRingoOnField = isOnField;
    }

    private void SpawnRingo()
    {
        // Calculate world position based on grid coordinates and cell size
        Vector2 spawnPosition = new Vector2(Random.Range(-_gridSizeX, _gridSizeX), Random.Range(-_gridSizeY, _gridSizeY));
        Instantiate(ringo, spawnPosition, Quaternion.identity);
    }
    
}
