using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // この関数をボタンから呼び出す
    public void LoadGameScene()
    {
        SceneManager.LoadScene("select"); // ゲームシーンの名前
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionScene()
    {
        SceneManager.LoadScene("option");
    }
}
