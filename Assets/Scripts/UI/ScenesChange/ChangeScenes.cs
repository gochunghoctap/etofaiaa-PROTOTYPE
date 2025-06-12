using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // この関数をボタンから呼び出す
    public void MenuScene()
    {
        SceneManager.LoadScene("menu");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("select");
    }

    public void QuitGame()
    {
        Debug.Log("ゲーム終了");
        Application.Quit();
    }

    public void OptionScene()
    {
        SceneManager.LoadScene("option");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("title");
    }
}
