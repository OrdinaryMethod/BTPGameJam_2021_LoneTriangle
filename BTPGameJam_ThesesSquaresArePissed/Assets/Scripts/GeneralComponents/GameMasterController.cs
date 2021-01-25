using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    public GameObject GameMaster;
    public int TotalEnemyMobs;
    public bool SpawnActive = false;
    public int SpawnLimit;
    public float TimeLeft;
    public int WaveCount;

    //Enemy Stats
    public int EnemyHealth;
    public int EnemySpeed;
    private int MinSpeed = 150;
    private int MaxSpeed = 170;
    public int EnemyDamage;


    // Start is called before the first frame update
    void Start()
    {
        //Starting enemy stats
        EnemyHealth = 5;
        EnemySpeed = Random.Range(MinSpeed, MaxSpeed);
        EnemyDamage = 5;

        //Wave timer start
        TimeLeft = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawnMonitor();
        CountdownController();
    }

    private void EnemySpawnMonitor()
    {
        TotalEnemyMobs = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void CountdownController()
    {
        TimeLeft -= Time.deltaTime;
        if(TimeLeft <  0 && !SpawnActive)
        {
            SpawnActive = true;
            TimeLeft = 15f;
            WaveCount = WaveCount + 1;
            IncreaseWaveDifficulty();
        }
        else if(TimeLeft < 0 && SpawnActive)
        {
            SpawnActive = false;
            TimeLeft = 1f;
        }
    }

    private void IncreaseWaveDifficulty()
    {
        MinSpeed = MinSpeed++;
        MaxSpeed = MaxSpeed++;
        EnemyHealth = EnemyHealth + 2;
        EnemySpeed = Random.Range(MinSpeed, MaxSpeed);
        EnemyDamage = EnemyDamage++;
    }
}
