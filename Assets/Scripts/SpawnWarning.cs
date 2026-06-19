using UnityEngine;

public class SpawnWarning : MonoBehaviour
{
    public float flashSpeed = 5f;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float alpha = Mathf.Abs(Mathf.Sin(Time.time * flashSpeed));
        Color color = sr.color;
        color.a = alpha;
        sr.color = color;
    }
}