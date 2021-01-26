using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMasterController : MonoBehaviour
{
    public GameObject GameMaster;
    public GameObject Player;
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


    //U.I Elements
    public Text UI_WaveCount;
    public Text UI_health;
    public Text UI_Speed;
    public Text UI_Ammo;


    // Start is called before the first frame update
    void Start()
    {
        //Starting enemy stats
        EnemyHealth = 5;
        EnemySpeed = Random.Range(MinSpeed, MaxSpeed);
        EnemyDamage = 5;

        //Wave timer start
        TimeLeft = 10f;
        WaveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawnMonitor();
        CountdownController();
        UserInterfaceMonitor();
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

    private void UserInterfaceMonitor()
    {
        //Player Health
        UI_health.text = Player.GetComponent<PlayerMovementController>().Health.ToString() + "%";
        UI_Speed.text = Player.GetComponent<PlayerMovementController>().speed.ToString() + "%";
        UI_Ammo.text = Player.GetComponentInChildren<PlayerWeaponController>().Ammo.ToString();
        UI_WaveCount.text = WaveCount.ToString();
    }
}
