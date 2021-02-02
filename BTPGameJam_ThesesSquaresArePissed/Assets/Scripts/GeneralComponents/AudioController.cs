using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject GameMaster;
    bool WaveActive = false;


    // Update is called once per frame
    void Update()
    {
        GameMasterMonitor();
        PlayAudio();
    }

    private void GameMasterMonitor()
    {
        WaveActive = GameMaster.GetComponent<GameMasterController>().SpawnActive;
        if(WaveActive)
        {

        }
    }

    private void PlayAudio()
    {
        if (WaveActive)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioClip>(), 0.5f);
        }   
    }
}
