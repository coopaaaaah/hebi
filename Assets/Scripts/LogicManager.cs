using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public RingoSpawner ringoSpawner;

    public void SpawnRingo()
    {
        ringoSpawner.SetIsRingoOnField(false);
    }
}
