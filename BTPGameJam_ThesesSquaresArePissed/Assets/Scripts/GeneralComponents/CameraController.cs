using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        PlayerMonitor();
    }

    private void PlayerMonitor()
    {
        Vector2 DeathPosition = Player.GetComponent<PlayerMovementController>().DeathPosition;

        if (Player.activeInHierarchy)
        {
            gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(DeathPosition.x, DeathPosition.y, gameObject.transform.position.z);
        }
    }
}
