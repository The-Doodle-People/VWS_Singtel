using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBGM : MonoBehaviour
{
    public AudioClip[] audioClips;

    AudioSource audioSource;
    int audioIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (audioIndex == audioClips.Length - 1)
            {
                audioIndex = 0;
            }
            else
            {
                audioIndex++;
            }

            audioSource.clip = audioClips[audioIndex];
            audioSource.Play();

        }
    }
}
