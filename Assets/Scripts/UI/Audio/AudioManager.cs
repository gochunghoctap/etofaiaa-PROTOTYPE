using UnityEngine;

public class AudioManger : MonoBehaviour
{
    void Awake()
    {
        if (Object.FindObjectsByType<AudioManger>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

}