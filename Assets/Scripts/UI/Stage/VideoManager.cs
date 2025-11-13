using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip p1WinVideo;
    public VideoClip p2WinVideo;

    void Start()
    {
        // Gán video dựa trên người thắng
        if (GameResult.winnerName == "Player1")
        {
            videoPlayer.clip = p1WinVideo;
        }
        else if (GameResult.winnerName == "Player2")
        {
            videoPlayer.clip = p2WinVideo;
        }
        else
        {
            Debug.LogWarning("Draw!");
        }

        videoPlayer.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("TestScene");
        }

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("menu");
        }

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("menu");
        }

    }
}