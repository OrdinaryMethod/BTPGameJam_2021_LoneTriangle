using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    GameObject Player;
    public float speed = 100;
    public int Health;
    public Vector2 DeathPosition;
    private Rigidbody2D rb2d;
    private bool IsFacingRight;
    public bool FlipGunBack;


    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject;
        rb2d = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        HealthMonitor();
        DeathPosition = Player.transform.position;
    }

    private void MovePlayer()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal") * speed;
        float MoveVertical = Input.GetAxis("Vertical") * speed;
        rb2d.velocity = new Vector2(MoveHorizontal, MoveVertical) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Collision = collision.gameObject.tag;
        switch (Collision)
        {
            case "Enemy":
                int EnemyDamage = collision.gameObject.GetComponentInChildren<EnemyCombatController>().Damage;
                Health = Health - EnemyDamage;
                rb2d.AddForce(new Vector2(2,2));
                Destroy(collision.gameObject);
                break;
        }
    }

    private void HealthMonitor()
    {
        if(Health <= 0)
        {
            Player.SetActive(false);
        }
    }
}
