using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmSource;
    public AudioSource seSource;

    private void Awake()
    {
        // シングルトン化
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも消えない
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSEVolume(float volume)
    {
        seSource.volume = volume;
        PlayerPrefs.SetFloat("SEVolume", volume);
    }

    public void LoadVolumes()
    {
        float bgmVol = PlayerPrefs.GetFloat("BGMVolume", 1f);
        float seVol = PlayerPrefs.GetFloat("SEVolume", 1f);
        bgmSource.volume = bgmVol;
        seSource.volume = seVol;
    }
}
