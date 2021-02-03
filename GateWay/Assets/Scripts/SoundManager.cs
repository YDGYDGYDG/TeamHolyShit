using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    // 오디오 클립
    public AudioClip [] audioClips;
    /*
     * 0: 
     * 1: 
     * 2:
     * 3: 
     * 4: 
     * 5: 
     * 6: 
     * 7: 
     * 8: 
     * 9: 
     * 10: 
     */

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();


    }

    public void ActiveSoundOneShot(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
    }

    public void ActiveSoundBGM(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

}
