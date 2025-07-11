using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bgmSlider;

    void Start()
    {
        // PlayerPrefsから音量を読み込み
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.7f); // デフォルトは0.7
        bgmSlider.value = savedVolume;

        // 読み込んだ音量をMixerに反映
        SetBGMVolume(savedVolume);

        // スライダーが変更されたときに反映＆保存
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    public void SetBGMVolume(float value)
    {
        // 0.0001未満になるとlogがNaNになるのでClamp
        float volume = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("BGM", volume);

        // 音量を保存
        PlayerPrefs.SetFloat("BGMVolume", value);
    }
}