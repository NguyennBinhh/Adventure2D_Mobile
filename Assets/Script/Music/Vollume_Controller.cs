using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Vollume_Controller : MonoBehaviour
{
    [SerializeField] private AudioMixer Audio_Mixer;
    [SerializeField] private Slider Sl_Music;
    [SerializeField] private Slider Sl_SFX;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVol") || PlayerPrefs.HasKey("SFXVol"))
        {
            Load_Volume();
        }
        else
        {
            Set_MusicVol();
            Set_SFXVol();
        }
    }
    public void Set_MusicVol()
    {
        float Vol = Sl_Music.value;
        Audio_Mixer.SetFloat("Music",Mathf.Log10(Vol) * 20);
        PlayerPrefs.SetFloat("MusicVol",Vol);
    }

    public void Set_SFXVol()
    {
        float Vol = Sl_SFX.value;
        Audio_Mixer.SetFloat("SFX", Mathf.Log10(Vol) * 20);
        PlayerPrefs.SetFloat("SFXVol",Vol);
    }

    public void Load_Volume()
    {
        Sl_Music.value = PlayerPrefs.GetFloat("MusicVol");
        Set_MusicVol();
        Sl_SFX.value = PlayerPrefs.GetFloat("SFXVol");
        Set_SFXVol();
    }    
}
