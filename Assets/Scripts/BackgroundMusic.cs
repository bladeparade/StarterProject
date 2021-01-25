using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public FairyScript fairyScript;
    public AudioClip backgroundMusic; 
    public AudioClip victoryClip;
    public AudioClip lossClip;
    public AudioClip pickupSound;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        GameObject fairyScriptObject = GameObject.FindWithTag("Fairy");
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
         if (fairyScript.win == true)
        {
        musicSource.clip = victoryClip;
        musicSource.Play();
        enabled = false;
        }

        else if (fairyScript.gameOver == true)
        {
        musicSource.clip = lossClip;
        musicSource.Play();
        enabled = false;
        }

    }
}
