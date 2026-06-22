using UnityEngine;
using TMPro;

public class TextFlash : MonoBehaviour
{
    public float flashSpeed = 2f;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        float alpha = Mathf.Abs(Mathf.Sin(Time.unscaledTime * flashSpeed));
        Color color = text.color;
        color.a = alpha;
        text.color = color;
    }
}