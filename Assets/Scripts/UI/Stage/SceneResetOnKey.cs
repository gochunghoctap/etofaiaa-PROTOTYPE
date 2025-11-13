using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetOnKey : MonoBehaviour
{
    void Update()
    {
        // Kiểm tra nếu người dùng nhấn phím Backspace
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            // Lấy scene hiện tại và load lại
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}