using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    public GameObject GameMaster;
    public int TotalEnemyMobs;
    public bool SpawnActive = false;
    public int SpawnLimit;
    public float TimeLeft = 100f;


    // Start is called before the first frame update
    void Start()
    {
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
            TimeLeft = 160f;
        }
        else if(TimeLeft < 0 && SpawnActive)
        {
            SpawnActive = false;
            TimeLeft = 100f;
        }
    }
}
