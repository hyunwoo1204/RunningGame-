using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundControll2 : MonoBehaviour
{
    public Slider Volume;

    public AudioSource audio;
    public AudioSource audio2;
    public AudioSource audio3;

    private float Vol = 1f;
    private float Vol2 = 1f;
    private float Vol3 = 1f;
    void Start()
    {
        Vol = PlayerPrefs.GetFloat("Volume", 1f);
        Volume.value = Vol;
        audio.volume = Volume.value;
        audio2.volume = Volume.value;
        audio3.volume = Volume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }
    public void SoundSlider()
    {
        audio.volume = Volume.value;
        audio2.volume = Volume.value;
        audio3.volume = Volume.value;
        Vol = Volume.value;
        PlayerPrefs.SetFloat("Vol", Vol);

  

    }

}

