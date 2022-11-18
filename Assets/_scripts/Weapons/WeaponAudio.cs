using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField]
    private AudioClip shootBulletClip = null, outOfBulletsClip = null;

    // hvergang man skyder så kommer der lyd
    public void PlayShootSound()
    {
        PlayClip(shootBulletClip);
    }

    //hvis man løber tør får bullet laver vore gun en lyd "no ammo"
    public void PlayNoBulletSound()
    {
        PlayClip(outOfBulletsClip);
    }

}
