using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    internal static AudioManagerScript instance;
    public AudioClip explodeSound;
    private AudioSource missileSource;

    // Use this for initialization

    private void Awake()
    {
        missileSource = GetComponent<AudioSource>();
        missileSource.PlayOneShot(explodeSound);
        Destroy(gameObject, 5);
    }

    /*  void PlayMissleExplosion()
      {
          missileSource.PlayOneShot(explodeSound);
          Destroy(gameObject, 5);
      }*/

}