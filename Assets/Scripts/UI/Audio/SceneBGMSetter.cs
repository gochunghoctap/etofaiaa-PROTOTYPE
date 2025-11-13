using UnityEngine;

public class SceneBGMSetter : MonoBehaviour
{
    public AudioClip sceneBGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayBGM(sceneBGM);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
