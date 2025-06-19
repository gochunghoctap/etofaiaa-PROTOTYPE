using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ���̊֐����{�^������Ăяo��
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
        Debug.Log("�Q�[���I��");
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
