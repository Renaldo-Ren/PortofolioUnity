using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioClip Eat;
    static AudioSource audioSrc;

    void Start()
    {
        Eat = Resources.Load<AudioClip>("audiomass-output");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "audiomass-output":
                audioSrc.PlayOneShot(Eat);
                break;
        }
    }
}
