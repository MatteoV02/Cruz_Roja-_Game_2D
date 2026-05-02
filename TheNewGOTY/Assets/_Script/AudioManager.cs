using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgAudioSource;
    public AudioSource sfxAudioSource;


    public AudioClip jump;
    public AudioClip coin;

    public Slider bgMusicVolSlider;
    // Start is called before the first frame update

    void Start()
    {
        bgMusicVolSlider.value = bgAudioSource.volume;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayJump()
    {
        Playsound(jump);
    }

    public void PlayCoin()
    {
        Playsound(coin);
    }



    private void Playsound(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }

    public void ChangeVolume(float volume)
    {
         bgAudioSource.volume = bgMusicVolSlider.value;
    }
}

