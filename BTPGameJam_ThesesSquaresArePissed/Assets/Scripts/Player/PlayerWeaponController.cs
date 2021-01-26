using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
	public GameObject FirePoint;
	public GameObject BulletPrefab;
	private Vector2 direction;
	public int Damage;
	private bool IsFacingRight;

	private float FireRate;
	public float SetFireRate;

	public int Ammo;

	public float AimSpeed = 100f; //Aim speed

    void Start()
    {
		Ammo = 100;
    }

    void Update()
	{
		AimDirection();
		SpawnBullet();
	}

	private void AimDirection()
    {
		direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, AimSpeed * Time.deltaTime);
	}

	private void SpawnBullet()
    {
		if(FireRate <= 0)
        {
			if (Input.GetKey(KeyCode.Mouse0))
			{
				if(Ammo > 0)
                {
					GameObject a = Instantiate(BulletPrefab, FirePoint.transform.position, Quaternion.identity) as GameObject;
					Rigidbody2D rb2d = a.GetComponent<Rigidbody2D>();
					rb2d.velocity = new Vector2(direction.x, direction.y) * 20;
					Destroy(a, 1);
					Ammo = Ammo - 1;
				}				
			}
			FireRate = SetFireRate;
		}
		else
        {
			FireRate -= Time.deltaTime;
        }
    }
}
