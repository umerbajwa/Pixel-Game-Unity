using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audio;
    public AudioClip collect;
    
    private void Awake()
    {

        instance = this;
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
}
