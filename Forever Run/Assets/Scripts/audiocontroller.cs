using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{
    
    bool isMuted = false;
    public AudioSource a1;



    private void Awake()
    {
        a1 = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    public void AudioMute()
    {

        a1.enabled = !a1.enabled;

    }
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}