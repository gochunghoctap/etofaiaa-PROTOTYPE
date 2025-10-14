using UnityEngine;
using UnityEngine.UIElements;

public class CreditPanelManager : MonoBehaviour
{
    public GameObject creditPanel;
    public CreditScroller scroller;

    public void ShowCredit()
    {
        creditPanel.SetActive(true);
        scroller.ResetScroll();
    }

    public void HideCredit()
    {
        creditPanel.SetActive(false);
    }
}
