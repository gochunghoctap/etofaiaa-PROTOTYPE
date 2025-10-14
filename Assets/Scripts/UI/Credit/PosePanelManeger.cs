using UnityEngine;
using UnityEngine.SceneManagement;

public class PosePanelManeger : MonoBehaviour
{
    public GameObject PosePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            ShowPose();
        }
    }

    public void ShowPose()
    {
        PosePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HidePose()
    {
        PosePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("title");
        Time.timeScale = 1f;
    }

    public void SelectScene()
    {
        SceneManager.LoadScene("select");
        Time.timeScale = 1f;
    }
}
