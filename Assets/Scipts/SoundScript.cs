using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip fireSound, coinSound, enemyDeath;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("laser_bullet");
        coinSound = Resources.Load<AudioClip>("coin");
        enemyDeath = Resources.Load<AudioClip>("enemy_death");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "laser_bullet":
                audioSrc.PlayOneShot(fireSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "enemy_death":
                audioSrc.PlayOneShot(enemyDeath);
                break;
    }
}
}
