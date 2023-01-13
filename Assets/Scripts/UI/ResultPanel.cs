using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void SetAsLast()
    {
        GetComponent<Image>().color = new Color(0.1780883f, 0.5471698f, 0.2139214f, 0.3921569f);
    }
}
