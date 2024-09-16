using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource Music_Source;
    [SerializeField] private AudioSource SFX_Source;

    [Header("Audio Clip")]
    public AudioClip Music_Clip;
    public AudioClip Jump_Clip;
    public AudioClip CheckPoint_Clip;
    public AudioClip Fruit_Clip;
    public AudioClip LvComplete_Clip;
    public AudioClip Fall_Clip;
    public AudioClip Click_Button;
    public static Audio_Manager instance;
 //   [SerializeField] private GameObject Music;

    

    public void Player_Music(AudioClip Adc)
    {
        Music_Source.clip = Adc;
        Music_Source.Play();
    }

    public void Play_SFX(AudioClip Adc)
    {
        SFX_Source.PlayOneShot(Adc);
    }    
}
