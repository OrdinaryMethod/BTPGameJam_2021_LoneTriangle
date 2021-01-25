using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombatController : MonoBehaviour
{
    public Transform AttackPosition;
    public LayerMask WhatIsEnemies;
    private Vector2 direction;
    
    private float SwingSpeed;
    public float SetSwingSpeed;
    public float AttackRange;
    public int Damage;
    public float AimSpeed = 100f; //Aim speed

    void Update()
    {
        AimDirection();
        SwingControls();        
    }

    private void AimDirection()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, AimSpeed * Time.deltaTime);
    }

    private void SwingControls()
    {
        if (SwingSpeed <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] DamagedEnemies = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange, WhatIsEnemies);
                for (int i = 0; i < DamagedEnemies.Length; i++)
                {
                   
                    DamagedEnemies[i].GetComponent<EnemyCombatController>().Health -= Damage;
                    string EnemyName = DamagedEnemies[i].GetComponent<EnemyCombatController>().name;
                    Debug.Log("You hit " + EnemyName + " for " + Damage + " damage.");
                }
            }
            SwingSpeed = SetSwingSpeed;
        }
        else
        {
            SwingSpeed -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, AttackRange);
    }

   
}
