using TMPro;
using UnityEngine;

public class RunTimeText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (GameManager.Instance.Running)
        {
            _text.text = GameManager.Instance.TimeInRun.ToString("0.00");
        }
        else
        {
            _text.text = string.Empty;
        }
    }
}
