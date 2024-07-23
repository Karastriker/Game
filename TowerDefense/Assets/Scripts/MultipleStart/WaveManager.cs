using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public WaveSpawner1 waveSpawner1;
    public WaveSpawner2 waveSpawner2;
    public GameManager gameManager;

    void Update()
    {
        if (AllWavesCompleted() && WaveSpawner1.EnemiesAlive == 0 && 
            WaveSpawner2.EnemiesAlive == 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    private bool AllWavesCompleted()
    {
        return waveSpawner1.HasCompletedAllWaves() && waveSpawner2.HasCompletedAllWaves();
    }
}
