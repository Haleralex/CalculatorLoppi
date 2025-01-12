using UnityEngine;
using UnityEngine.UI;

public class DynamicScrollView : MonoBehaviour
{
    [SerializeField] private RectTransform mainWindow;
    [SerializeField] private RectTransform scrollViewRect;
    [SerializeField] private RectTransform contentRect;
    [SerializeField] private TMPro.TextMeshProUGUI textContent;
    [SerializeField] private float defaultHeightForLine;

    [SerializeField] private float maximumHeightForMainWindow;

    void Start()
    {
        UpdateScrollView();
    }


    public void UpdateScrollView()
    {
        var linesAmount = textContent.text.Split('\n').Length - 1;
        if (mainWindow.sizeDelta.y != maximumHeightForMainWindow)
        {
            linesAmount = Mathf.Min(linesAmount, 4);
            Vector2 mainWindowSizeDelta = mainWindow.sizeDelta;
            mainWindowSizeDelta.y = 500 + linesAmount * defaultHeightForLine;
            mainWindow.sizeDelta = mainWindowSizeDelta;

            Vector2 scrollViewRectSizeDelta = scrollViewRect.sizeDelta;
            scrollViewRectSizeDelta.y = 175 + linesAmount * 20;
            scrollViewRect.sizeDelta = scrollViewRectSizeDelta;
        }
        Vector2 sizeDelta = contentRect.sizeDelta;
        sizeDelta.y = defaultHeightForLine * linesAmount;
        contentRect.sizeDelta = sizeDelta;
    }
}
