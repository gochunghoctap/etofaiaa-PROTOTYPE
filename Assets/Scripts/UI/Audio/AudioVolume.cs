using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bgmSlider;

    void Start()
    {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    public void SetBGMVolume(float value)
    {
        float volume = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("BGM", volume);
    }
}