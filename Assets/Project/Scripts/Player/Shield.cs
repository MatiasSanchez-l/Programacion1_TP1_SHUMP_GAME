using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float pulseDuration = 0.6f; // segundos de opaco a transparente
    [SerializeField, Range(0f, 1f)] private float minAlpha = 0.2f;
    [SerializeField, Range(0f, 1f)] private float maxAlpha = 0.7f;

    public bool IsActive => gameObject.activeSelf;

    public void Activate()   { gameObject.SetActive(true); }
    public void Deactivate() { gameObject.SetActive(false); }

    void Update(){
        float t = Mathf.PingPong(Time.time / pulseDuration, 1f);

        Color color = spriteRenderer.color;
        color.a = Mathf.Lerp(minAlpha, maxAlpha, t);
        spriteRenderer.color = color;
    }
}
