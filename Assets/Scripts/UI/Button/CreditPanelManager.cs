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
        creditPanel.SetActive(false);
    }
}
