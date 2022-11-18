using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Secret : MonoBehaviour
{
    public AudioSource AudioSource;
    public BoxCollider2D BoxCollider2D;

    public void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.Play();
    }
}
