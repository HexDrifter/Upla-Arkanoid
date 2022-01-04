using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBeep : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D()
    {
        audioSource.Play();
    }
}
