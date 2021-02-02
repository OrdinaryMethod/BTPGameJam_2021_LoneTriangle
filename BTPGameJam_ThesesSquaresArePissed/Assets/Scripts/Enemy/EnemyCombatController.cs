using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    private GameObject Target;
    private Vector2 TargetPosition;
    private Rigidbody2D rb2d;
    public float Speed;
    public int Health;
    public int Damage;

    //Droppable Items
    public GameObject HealthDrop;
    public GameObject SpeedDrop;
    public GameObject AmmoDrop;
    private void Awake()
    {
        Target = GameObject.Find("Player");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        GetStatsFromGM();
    }

    private void GetStatsFromGM()
    {
        Speed = GameObject.Find("GameMaster").GetComponent<GameMasterController>().EnemySpeed;
        Health = GameObject.Find("GameMaster").GetComponent<GameMasterController>().EnemyHealth;
        Damage = GameObject.Find("GameMaster").GetComponent<GameMasterController>().EnemyDamage;
    }

    // Update is called once per frame
    void Update()
    {
        AggroControl();
        EnemyHealthMonitor();
    }

    //Enemy Movement
    private void AggroControl()
    {
        if (Target != null)
        {
            TargetPosition = Target.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
        }        
    }

    private void  EnemyHealthMonitor()
    {
        if(Health <= 0)
        {
            int ItemDrop = Random.Range(1, 100);
            
            if(ItemDrop >= 1 && ItemDrop < 20)
            {
                GameObject a = Instantiate(HealthDrop, transform.position, Quaternion.identity) as GameObject;
            }
            else if(ItemDrop >= 20 && ItemDrop < 35)
            {
                GameObject a = Instantiate(SpeedDrop, transform.position, Quaternion.identity) as GameObject;
            }
            else if(ItemDrop >= 35 && ItemDrop < 75)
            {
                GameObject a = Instantiate(AmmoDrop, transform.position, Quaternion.identity) as GameObject;
            }


            
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Collision = collision.gameObject.name;

        switch (Collision)
        {
            case "Bullet(Clone)":
                int EnemyDamage = Target.GetComponentInChildren<PlayerWeaponController>().Damage;
                Health = Health - EnemyDamage;
                break;
        }
    }
}
