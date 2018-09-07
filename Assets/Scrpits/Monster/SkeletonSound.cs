using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSound : MonoBehaviour {
    public Monster monster;
    public AudioClip[] Sound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (monster.hp <= 0)
        {
            SoundPlay(1);
        }
        if (monster.isHit == true)
        {
            SoundPlay(0);
        }
    }
    public void SoundPlay(int Num)
    {
        GetComponent<AudioSource>().clip = Sound[Num];
        GetComponent<AudioSource>().Play();
    }
}
