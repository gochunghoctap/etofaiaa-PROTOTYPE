using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject P1Button;
    public GameObject P2Button;

    public Transform P1pos;
    public Transform P2pos;

    public string nextSceneName;

    void Start()
    {
        P1Button.gameObject.SetActive(true);
        P2Button.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (P1pos != null)
        {
            P1pos.gameObject.SetActive(false);
            P2pos.gameObject.SetActive(true);
        }


        if (P1pos != null && P2pos != null)
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
