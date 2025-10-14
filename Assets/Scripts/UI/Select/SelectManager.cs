using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject P1Button;
    public GameObject P2Button;

    public Transform P1pos;
    public Transform P2pos;

    public string nextSceneName;


    private bool p1selected;
    private bool p2selected;

    void Start()
    {
        P1Button.gameObject.SetActive(true);
        P2Button.gameObject.SetActive(false);

        p1selected = false;
        p2selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!P1pos.gameObject.activeSelf)
        {
            p1selected = true;
            P1Button.gameObject.SetActive(false);
            P2Button.gameObject.SetActive(true);

        }

        if (!P2pos.gameObject.activeSelf)
        {
            p2selected = true;
            P2Button.gameObject.SetActive(false);
        }

        if (p1selected==true && p2selected == true)
        {
            StartCoroutine(ChangeSceneAfterDelay(3f));//キャラ選んだらｎ秒後にシーンチェンジ
        }
    }





    private System.Collections.IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
