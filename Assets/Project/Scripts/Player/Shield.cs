/**
 * @author Matias
 * @create date 2026-10-03 15:13:12
 * @modify date 2026-10-06 00:16:42
 * @desc escudo del jugador con efecto de pulso de transparencia
 */
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float pulseDuration = 0.6f;
    [SerializeField, Range(0f, 1f)] private float minAlpha = 0.1f;
    [SerializeField, Range(0f, 1f)] private float maxAlpha = 0.3f;

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
