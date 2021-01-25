using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public GameObject SquareSoldierPrefab;
    public float RespawnTime;
    private bool EnemyWaveIsActive;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSquareSoldiers());
    }

    void Update()
    {
        GameMasterDirections();
        RespawnTime = Random.Range(3, 15);
    }

    //Get directions from GameMaster
    private void GameMasterDirections()
    {
        EnemyWaveIsActive = GameObject.Find("GameMaster").GetComponent<GameMasterController>().SpawnActive;
    }
    
    //Enemy Spawn Coroutine
    IEnumerator SpawnSquareSoldiers()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnEmeny();
        }
    }

    private void SpawnEmeny()
    {
        if (EnemyWaveIsActive) //Check with GameMaster if its okay to create more objects
        {
            GameObject a = Instantiate(SquareSoldierPrefab, transform.position, Quaternion.identity) as GameObject;
        }
    }
}
