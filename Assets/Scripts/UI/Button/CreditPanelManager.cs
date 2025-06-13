using UnityEngine;

public class CreditPanelManager : MonoBehaviour
{
    public GameObject creditPanel;

    public void ShowCredit()
    {
        creditPanel.SetActive(true);
    }

    public void HideCredit()
    {
        Debug.Log("HideCredit called");
        creditPanel.SetActive(false);
    }
}
